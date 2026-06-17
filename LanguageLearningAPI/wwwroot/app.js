"use strict";

const API = "/api/Api";
const app = document.getElementById("app");

// ---- tiny helpers ---------------------------------------------------------
const el = (sel) => document.querySelector(sel);
const esc = (s) =>
    String(s ?? "").replace(/[&<>"']/g, (c) => ({
        "&": "&amp;", "<": "&lt;", ">": "&gt;", '"': "&quot;", "'": "&#39;",
    }[c]));

async function getJSON(path) {
    const res = await fetch(API + path);
    if (!res.ok) throw new Error(`${res.status} ${res.statusText}`);
    return res.json();
}

function showError(err) {
    app.innerHTML = `<div class="error">⚠️ Nie udało się wczytać danych: ${esc(err.message)}</div>`;
}

// ---- data (cached for the session) ---------------------------------------
let groups = null;     // [{groupID, groupName, description, sourceLanguage, targetLanguage}]
let pairsByGroup = null; // { [groupID]: [pair, ...] }
let activeLang = "all";  // currently selected language tab (target language code = the language being learned)
let activeLevel = "all"; // currently selected difficulty filter ("all" | Beginner | Medium | Advanced)

// ISO 639-1 -> Polish display name (falls back to upper-cased code)
const LANG_NAMES = {
    en: "Angielski", pl: "Polski", es: "Hiszpański", it: "Włoski",
    de: "Niemiecki", fr: "Francuski", pt: "Portugalski",
};
const langLabel = (code) => LANG_NAMES[code] || String(code).toUpperCase();

// Difficulty level -> Polish label + ordering (Beginner < Medium < Advanced)
const LEVEL_NAMES = { Beginner: "Początkujący", Medium: "Średni", Advanced: "Zaawansowany" };
const LEVEL_ORDER = { Beginner: 0, Medium: 1, Advanced: 2 };
const levelOf = (g) => g.level || "Beginner";
const levelLabel = (lvl) => LEVEL_NAMES[lvl] || lvl;
const levelClass = (lvl) => `lvl-${String(lvl).toLowerCase()}`;

// Polish plural for the item/word count: 1 słówko, 2-4 słówka, 5+ słówek
function plWords(n) {
    const mod10 = n % 10, mod100 = n % 100;
    if (n === 1) return "słówko";
    if (mod10 >= 2 && mod10 <= 4 && (mod100 < 12 || mod100 > 14)) return "słówka";
    return "słówek";
}

async function loadData() {
    const [g, pairs] = await Promise.all([
        getJSON("/translation-groups"),
        getJSON("/translation-pairs"),
    ]);
    groups = g;
    pairsByGroup = {};
    for (const p of pairs) {
        (pairsByGroup[p.groupID] ??= []).push(p);
    }
}

// ---- views ----------------------------------------------------------------
function renderGroups() {
    if (!groups.length) {
        app.innerHTML = `<p class="empty">Brak grup tłumaczeń.</p>`;
        return;
    }

    // distinct target languages present (the language being learned), for the tab bar
    const langs = [...new Set(groups.map((g) => g.targetLanguage))]
        .sort((a, b) => langLabel(a).localeCompare(langLabel(b)));

    // default to (or fall back to) the first language; there is no "all" tab
    if (!langs.includes(activeLang)) activeLang = langs[0];

    const tabFor = (code, label) =>
        `<button class="tab${activeLang === code ? " active" : ""}" data-lang="${esc(code)}">${esc(label)}</button>`;
    const tabs = langs.map((c) => tabFor(c, langLabel(c))).join("");

    // difficulty selector: "all" + each level present for the active language
    const levelsForLang = new Set(
        groups.filter((g) => g.targetLanguage === activeLang).map(levelOf));
    if (activeLevel !== "all" && !levelsForLang.has(activeLevel)) activeLevel = "all";
    const optFor = (val, label) =>
        `<option value="${esc(val)}"${activeLevel === val ? " selected" : ""}>${esc(label)}</option>`;
    const levelOptions = [optFor("all", "Wszystkie poziomy")]
        .concat(["Beginner", "Medium", "Advanced"]
            .filter((l) => levelsForLang.has(l))
            .map((l) => optFor(l, levelLabel(l))))
        .join("");

    const visible = groups
        .filter((g) => g.targetLanguage === activeLang)
        .filter((g) => activeLevel === "all" || levelOf(g) === activeLevel)
        // show easier groups first, then alphabetically within a level
        .slice()
        .sort((a, b) =>
            (LEVEL_ORDER[levelOf(a)] ?? 9) - (LEVEL_ORDER[levelOf(b)] ?? 9) ||
            a.groupName.localeCompare(b.groupName));

    const cards = visible.map((g) => {
        const count = (pairsByGroup[g.groupID] || []).length;
        const lvl = levelOf(g);
        return `
        <div class="card ${levelClass(lvl)}" data-group="${g.groupID}">
            <span class="level ${levelClass(lvl)}">${esc(levelLabel(lvl))}</span>
            <h3>${esc(g.groupName)}</h3>
            <p>${esc(g.description || "")}</p>
            <div class="card-meta">
                <span class="badge">${esc(langLabel(g.sourceLanguage))} → ${esc(langLabel(g.targetLanguage))}</span>
                <span class="count">${count} ${plWords(count)}</span>
            </div>
        </div>`;
    }).join("");

    app.innerHTML = `
        <h2 class="view-title">Grupy tłumaczeń</h2>
        <p class="subtitle">Wybierz zestaw, aby przeglądać lub ćwiczyć.</p>
        <div class="tabs" role="tablist">${tabs}</div>
        <div class="filterbar">
            <label class="filter-label" for="levelSelect">Poziom trudności:</label>
            <select id="levelSelect" class="select">${levelOptions}</select>
        </div>
        ${visible.length
            ? `<div class="grid">${cards}</div>`
            : `<p class="empty">Brak grup dla wybranych filtrów.</p>`}`;

    app.querySelectorAll(".tab").forEach((t) =>
        t.addEventListener("click", () => { activeLang = t.dataset.lang; renderGroups(); }));
    el("#levelSelect").addEventListener("change", (e) => { activeLevel = e.target.value; renderGroups(); });
    app.querySelectorAll(".card").forEach((c) =>
        c.addEventListener("click", () => renderGroupDetail(Number(c.dataset.group))));
}

function renderGroupDetail(groupId) {
    const g = groups.find((x) => x.groupID === groupId);
    const pairs = pairsByGroup[groupId] || [];
    const rows = pairs.map((p) => `
        <tr>
            <td>${esc(p.sourceContent)}</td>
            <td>${esc(p.targetContent)}</td>
        </tr>`).join("");

    app.innerHTML = `
        <div class="crumbs"><a id="back">← Wszystkie grupy</a></div>
        <h2 class="view-title">${esc(g.groupName)}</h2>
        <p class="subtitle">
            <span class="badge">${esc(langLabel(g.sourceLanguage))} → ${esc(langLabel(g.targetLanguage))}</span>
            &nbsp; ${esc(g.description || "")}
        </p>
        <div class="toolbar">
            <button class="btn primary" id="practice" ${pairs.length ? "" : "disabled"}>▶ Ćwicz (${pairs.length})</button>
        </div>
        ${pairs.length ? `
        <table>
            <thead><tr>
                <th>${esc(langLabel(g.sourceLanguage))}</th>
                <th>${esc(langLabel(g.targetLanguage))}</th>
            </tr></thead>
            <tbody>${rows}</tbody>
        </table>` : `<p class="empty">Brak par w tej grupie.</p>`}`;

    el("#back").addEventListener("click", renderGroups);
    const practice = el("#practice");
    if (practice && pairs.length) {
        practice.addEventListener("click", () => renderPractice(g, pairs));
    }
}

function renderPractice(g, pairs) {
    let i = 0;
    let revealed = false;

    function draw() {
        const p = pairs[i];
        app.innerHTML = `
            <div class="crumbs"><a id="back">← ${esc(g.groupName)}</a></div>
            <div class="flash-wrap">
                <div class="progress">Karta ${i + 1} / ${pairs.length}</div>
                <div class="flashcard" id="card">
                    <div class="flash-lang">${esc(langLabel(g.sourceLanguage))}</div>
                    <div class="flash-term">${esc(p.sourceContent)}</div>
                    ${revealed
                        ? `<div class="flash-lang" style="margin-top:18px">${esc(langLabel(g.targetLanguage))}</div>
                           <div class="flash-answer">${esc(p.targetContent)}</div>`
                        : `<div class="flash-hint">Kliknij, aby odsłonić</div>`}
                </div>
                <div class="flash-controls">
                    <button class="btn" id="prev" ${i === 0 ? "disabled" : ""}>← Poprzednia</button>
                    <button class="btn primary" id="next" ${i === pairs.length - 1 ? "disabled" : ""}>Następna →</button>
                </div>
            </div>`;

        el("#back").addEventListener("click", () => renderGroupDetail(g.groupID));
        el("#card").addEventListener("click", () => { revealed = !revealed; draw(); });
        el("#prev").addEventListener("click", () => { if (i > 0) { i--; revealed = false; draw(); } });
        el("#next").addEventListener("click", () => { if (i < pairs.length - 1) { i++; revealed = false; draw(); } });
    }
    draw();
}

// ---- boot -----------------------------------------------------------------
document.getElementById("homeLink").addEventListener("click", () => {
    if (groups) renderGroups();
});

(async function init() {
    try {
        await loadData();
        renderGroups();
    } catch (err) {
        showError(err);
    }
})();
