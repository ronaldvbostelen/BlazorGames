window.setTitle = (title) => {
    document.title = title + " | WASM";
};

scrollToBottom = () => {
    window.scrollTo(0, document.body.scrollHeight);
};