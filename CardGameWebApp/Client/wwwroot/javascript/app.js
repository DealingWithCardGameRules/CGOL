function sync_scroll() {
    /* Scroll result to scroll coords of event - sync with textarea */
    let editing = document.querySelector("#editing");
    let highlighting = document.querySelector("#highlighting");
    // Get and set x and y
    highlighting.scrollTop = editing.scrollTop;
    highlighting.scrollLeft = editing.scrollLeft;
}

$(document).ready(function () {
    $("body").tooltip({ selector: '[data-toggle=tooltip]', html: true });
});

function hideNavBar() {
    $(".sidebar").hide();
}

function copyText() {
    let text = $("#gamelink").val();
    navigator.clipboard.writeText(text).then(function () {
        alert("Copied to clipboard!");
    })
    .catch(function (error) {
        alert(error);
    });
}

window.getSelectedStart = (element) => {
    return element.selectionStart;
}
window.setCaret = (element, pos) => {
    element.selectionStart = pos;
    element.selectionEnd = pos;
}
