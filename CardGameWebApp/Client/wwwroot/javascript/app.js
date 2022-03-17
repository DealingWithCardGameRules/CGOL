﻿function sync_scroll() {
    /* Scroll result to scroll coords of event - sync with textarea */
    let editing = document.querySelector("#editing");
    let highlighting = document.querySelector("#highlighting");
    // Get and set x and y
    highlighting.scrollTop = editing.scrollTop;
    highlighting.scrollLeft = editing.scrollLeft;
}