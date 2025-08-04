mergeInto(LibraryManager.library, {
    OpenUnfocusedTab: function (urlPtr) {
        var url = UTF8ToString(urlPtr); // Convert pointer to JS string
        var newTab = window.open(url, '_blank');
        if (newTab) {
            newTab.blur();
            window.focus();
        }
    }
});
