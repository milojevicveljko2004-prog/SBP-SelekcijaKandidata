let zCounter = 1000;
const openStack = [];

function bringToFront(el) {
    zCounter += 2;
    el.style.zIndex = zCounter;
}

function centerWindow(el, width, height) {
    const dw = window.innerWidth;
    const dh = window.innerHeight - 34;
    const left = Math.max(8, (dw - width) / 2 + (openStack.length * 18) % 80);
    const top = Math.max(8, (dh - height) / 2 + (openStack.length * 18) % 80);
    el.style.left = left + "px";
    el.style.top = top + "px";
}

function makeDraggable(win, handle) {
    let dragging = false;
    let startX, startY, startLeft, startTop;

    handle.addEventListener("mousedown", (e) => {
        if (e.target.closest(".win-btn")) return;
        dragging = true;
        win.classList.add("dragging");
        startX = e.clientX;
        startY = e.clientY;
        const rect = win.getBoundingClientRect();
        const parentRect = win.parentElement.getBoundingClientRect();
        startLeft = rect.left - parentRect.left;
        startTop = rect.top - parentRect.top;
        bringToFront(win.parentElement);
        e.preventDefault();
    });

    window.addEventListener("mousemove", (e) => {
        if (!dragging) return;
        const dx = e.clientX - startX;
        const dy = e.clientY - startY;
        win.style.left = Math.max(0, startLeft + dx) + "px";
        win.style.top = Math.max(0, startTop + dy) + "px";
    });

    window.addEventListener("mouseup", () => {
        if (dragging) {
            dragging = false;
            win.classList.remove("dragging");
        }
    });
}

function makeResizable(win, handle, onResize) {
    let resizing = false;
    let startX, startY, startW, startH;

    handle.addEventListener("mousedown", (e) => {
        resizing = true;
        startX = e.clientX;
        startY = e.clientY;
        startW = win.offsetWidth;
        startH = win.offsetHeight;
        e.preventDefault();
        e.stopPropagation();
    });

    window.addEventListener("mousemove", (e) => {
        if (!resizing) return;
        const dw = e.clientX - startX;
        const dh = e.clientY - startY;
        win.style.width = Math.max(320, startW + dw) + "px";
        win.style.height = Math.max(180, startH + dh) + "px";
        if (onResize) onResize();
    });

    window.addEventListener("mouseup", () => {
        resizing = false;
    });
}
function openModal(opts) {
    if (opts.page) {
        return new Promise((resolve) => {
            const desktop = document.getElementById("desktop");
            desktop.innerHTML = "";

            const page = document.createElement("main");
            page.className = "app-page";

            const header = document.createElement("header");
            header.className = "page-header";

            const backBtn = document.createElement("button");
            backBtn.className = "back-link";
            backBtn.type = "button";
            backBtn.innerHTML = "&#8592; <span>Nazad</span>";
            backBtn.addEventListener("click", () => {
                const currentFile = window.location.pathname.split("/").pop().toLowerCase();
                if (["posebni-praksa.html", "posebni-privremeni.html", "posebni-sezonski.html"].includes(currentFile)) {
                    window.location.href = "oglasi.html";
                    return;
                }

                if (window.history.length > 1) window.history.back();
                else window.location.href = "index.html";
            });

            const heading = document.createElement("div");
            heading.className = "page-heading";
            const titleText = document.createElement("h1");
            titleText.textContent = opts.title || "";
            heading.appendChild(titleText);

            const statusbar = document.createElement("div");
            statusbar.className = "page-status";
            statusbar.textContent = opts.statusText || "";

            header.appendChild(backBtn);
            header.appendChild(heading);
            header.appendChild(statusbar);

            const body = document.createElement("section");
            body.className = "page-body";

            page.appendChild(header);
            page.appendChild(body);
            desktop.appendChild(page);

            let closed = false;
            const winCtl = {
                rootEl: page,
                bodyEl: body,
                setTitle: (t) => { titleText.textContent = t; },
                setStatus: (t) => { statusbar.textContent = t; },
                close: (result) => {
                    if (closed) return;
                    closed = true;
                    resolve(result);
                    if (window.history.length > 1) window.history.back();
                    else window.location.href = "index.html";
                }
            };

            try {
                const result = opts.build(body, winCtl);
                if (result && typeof result.then === "function") result.catch((err) => {
                    console.error(err);
                    body.innerHTML = `<div class="listview-empty">Greska pri prikazu stranice: ${escapeHtml(err.message || String(err))}</div>`;
                });
            } catch (err) {
                console.error(err);
                body.innerHTML = `<div class="listview-empty">Greska pri prikazu stranice: ${escapeHtml(err.message || String(err))}</div>`;
            }
        });
    }
    return new Promise((resolve) => {
        const desktop = document.getElementById("desktop");

        const overlay = document.createElement("div");
        overlay.className = "modal-overlay";
        bringToFront(overlay);

        const winEl = document.createElement("div");
        winEl.className = "win";
        winEl.style.width = (opts.width || 480) + "px";
        if (opts.height) winEl.style.height = opts.height + "px";
        bringToFront(winEl);
        winEl.style.zIndex = Number(overlay.style.zIndex) + 1;

        const titlebar = document.createElement("div");
        titlebar.className = "win-titlebar";
        titlebar.innerHTML = `<span class="win-title-text"></span>`;
        const titleText = titlebar.querySelector(".win-title-text");
        titleText.textContent = opts.title || "";

        const closeBtn = document.createElement("div");
        closeBtn.className = "win-btn";
        closeBtn.textContent = "\u2715";
        closeBtn.title = "Zatvori";
        titlebar.appendChild(closeBtn);

        const body = document.createElement("div");
        body.className = "win-body";

        const statusbar = document.createElement("div");
        statusbar.className = "win-statusbar";
        statusbar.textContent = opts.statusText || "";

        winEl.appendChild(titlebar);
        winEl.appendChild(body);
        winEl.appendChild(statusbar);

        if (opts.resizable) {
            const handle = document.createElement("div");
            handle.className = "win-resize-handle";
            winEl.appendChild(handle);
            makeResizable(winEl, handle);
        }

        desktop.appendChild(overlay);
        desktop.appendChild(winEl);
        centerWindow(winEl, opts.width || 480, opts.height || 320);
        makeDraggable(winEl, titlebar);

        let closed = false;
        const winCtl = {
            rootEl: winEl,
            bodyEl: body,
            setTitle: (t) => { titleText.textContent = t; },
            setStatus: (t) => { statusbar.textContent = t; },
            close: (result) => {
                if (closed) return;
                closed = true;
                desktop.removeChild(overlay);
                desktop.removeChild(winEl);
                const idx = openStack.indexOf(winCtl);
                if (idx >= 0) openStack.splice(idx, 1);
                resolve(result);
            }
        };

        closeBtn.addEventListener("click", () => winCtl.close(undefined));
        winEl.addEventListener("mousedown", () => bringToFront(winEl));
        openStack.push(winCtl);

        try {
            opts.build(body, winCtl);
        } catch (err) {
            console.error(err);
            body.innerHTML = `<div class="listview-empty">Greska pri prikazu prozora: ${escapeHtml(err.message || String(err))}</div>`;
        }
    });
}

const MsgIcon = { INFO: "info", WARN: "warn", ERROR: "error", QUESTION: "question" };
const iconGlyph = { info: "i", warn: "!", error: "\u2715", question: "?" };

function msgBox(message, title, buttons, icon) {
    buttons = buttons || ["OK"];
    icon = icon || MsgIcon.INFO;
    title = title || "Obavestenje";

    return openModal({
        title,
        width: 360,
        build: (body, win) => {
            body.innerHTML = `
                <div class="msgbox-body">
                    <div class="msgbox-icon ${icon}">${iconGlyph[icon]}</div>
                    <div class="msgbox-text"></div>
                </div>
                <div class="btn-row right"></div>
            `;
            body.querySelector(".msgbox-text").textContent = message;
            const row = body.querySelector(".btn-row");
            buttons.forEach((label, i) => {
                const btn = document.createElement("button");
                btn.className = "winbtn" + (i === 0 ? " primary" : "");
                btn.textContent = label;
                btn.addEventListener("click", () => win.close(label));
                row.appendChild(btn);
            });
        }
    });
}

async function alertBox(message, title = "Obavestenje", icon = MsgIcon.INFO) {
    await msgBox(message, title, ["OK"], icon);
}

async function confirmBox(message, title = "Pitanje", icon = MsgIcon.QUESTION) {
    const result = await msgBox(message, title, ["OK", "Otkazi"], icon);
    return result === "OK";
}

async function confirmYesNo(message, title = "Potvrda", icon = MsgIcon.WARN) {
    const result = await msgBox(message, title, ["Da", "Ne"], icon);
    return result === "Da";
}

async function errorBox(message, title = "Greska") {
    await msgBox(message, title, ["OK"], MsgIcon.ERROR);
}

function escapeHtml(str) {
    if (str === null || str === undefined) return "";
    return String(str)
        .replaceAll("&", "&amp;")
        .replaceAll("<", "&lt;")
        .replaceAll(">", "&gt;")
        .replaceAll('"', "&quot;");
}

function el(tag, attrs = {}, children = []) {
    const e = document.createElement(tag);
    for (const [k, v] of Object.entries(attrs)) {
        if (k === "class") e.className = v;
        else if (k === "html") e.innerHTML = v;
        else if (k.startsWith("on") && typeof v === "function") e.addEventListener(k.slice(2), v);
        else e.setAttribute(k, v);
    }
    (Array.isArray(children) ? children : [children]).forEach((c) => {
        if (c === null || c === undefined) return;
        e.appendChild(typeof c === "string" ? document.createTextNode(c) : c);
    });
    return e;
}

function fieldRow(labelText, inputEl, opts = {}) {
    const label = el("label", { class: "field-label", for: inputEl.id || "" }, labelText);
    const wrap = el("div", {}, [inputEl]);
    if (opts.full) {
        wrap.classList.add("form-row-full");
        return [el("div", { class: "form-row-full" }, [
            el("div", { class: "section-title" }, labelText)
        ]), wrap];
    }
    return [label, wrap];
}

function makeInput(type, id, value) {
    const input = el("input", { type, id });
    if (value !== undefined && value !== null) input.value = value;
    return input;
}

function makeTextarea(id, value) {
    const t = el("textarea", { id });
    t.value = value || "";
    return t;
}

function makeSelect(id, options, selected) {
    const select = el("select", { id });
    options.forEach((opt) => {
        const o = el("option", { value: opt }, prettyEnum(opt));
        if (opt === selected) o.selected = true;
        select.appendChild(o);
    });
    return select;
}

function prettyEnum(value) {
    if (!value) return "";
    return value
        .split("_")
        .map((w) => w.charAt(0) + w.slice(1).toLowerCase())
        .join(" ");
}

function makeCheckbox(id, checked) {
    const c = el("input", { type: "checkbox", id });
    c.checked = !!checked;
    return c;
}

function toDateInputValue(isoStr) {
    if (!isoStr) return "";
    return isoStr.substring(0, 10);
}

function toTimeInputValue(isoStr) {
    if (!isoStr) return "00:00";
    const d = new Date(isoStr);
    if (isNaN(d)) return "00:00";
    return d.toTimeString().substring(0, 5);
}

function dateInputToIso(dateVal) {
    if (!dateVal) return null;
    return new Date(dateVal + "T00:00:00").toISOString();
}

function dateInputToEndOfDayIso(dateVal) {
    if (!dateVal) return null;
    return new Date(dateVal + "T23:59:59").toISOString();
}

function timeInputToIso(timeVal, baseDate) {
    const datePart = baseDate ? baseDate : new Date().toISOString().substring(0, 10);
    const t = timeVal || "00:00";
    return new Date(`${datePart}T${t}:00`).toISOString();
}

function formatDate(isoStr) {
    if (!isoStr) return "";
    const d = new Date(isoStr);
    if (isNaN(d)) return String(isoStr);
    return d.toLocaleDateString("sr-Latn-RS");
}

function formatDateTime(isoStr) {
    if (!isoStr) return "";
    const d = new Date(isoStr);
    if (isNaN(d)) return String(isoStr);
    return d.toLocaleDateString("sr-Latn-RS") + " " + d.toTimeString().substring(0, 5);
}

function formatTime(isoStr) {
    if (!isoStr) return "";
    const d = new Date(isoStr);
    if (isNaN(d)) return String(isoStr);
    return d.toTimeString().substring(0, 5);
}

function formatMoney(val) {
    if (val === null || val === undefined || val === "") return "-";
    const n = Number(val);
    return n.toLocaleString("sr-Latn-RS", { maximumFractionDigits: 2 });
}

function buildListView({ columns, rows, rowId, emptyText }) {
    const wrap = el("div", { class: "listview-wrap" });
    let selectedId = null;
    let selectionListeners = [];

    function render() {
        wrap.innerHTML = "";
        if (!rows || rows.length === 0) {
            wrap.appendChild(el("div", { class: "listview-empty" }, emptyText || "Nema podataka za prikaz."));
            return;
        }
        const table = el("table", { class: "listview" });
        const thead = el("thead", {}, [
            el("tr", {}, columns.map((c) => el("th", {}, c.header)))
        ]);
        const tbody = el("tbody");
        rows.forEach((row) => {
            const id = rowId(row);
            const tr = el("tr", {});
            if (id === selectedId) tr.classList.add("selected");
            columns.forEach((c) => {
                tr.appendChild(el("td", {}, c.render(row)));
            });
            tr.addEventListener("click", () => {
                selectedId = id;
                tbody.querySelectorAll("tr").forEach((r) => r.classList.remove("selected"));
                tr.classList.add("selected");
                selectionListeners.forEach((fn) => fn(row));
            });
            tbody.appendChild(tr);
        });
        table.appendChild(thead);
        table.appendChild(tbody);
        wrap.appendChild(table);
    }

    render();

    return {
        el: wrap,
        setRows(newRows) {
            rows = newRows;
            if (!rows.find((r) => rowId(r) === selectedId)) selectedId = null;
            render();
        },
        getSelected() {
            return rows.find((r) => rowId(r) === selectedId) || null;
        },
        onSelect(fn) {
            selectionListeners.push(fn);
        },
        clearSelection() {
            selectedId = null;
            render();
        }
    };
}
