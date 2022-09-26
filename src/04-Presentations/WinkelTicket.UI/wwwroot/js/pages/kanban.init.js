dragula(
  [
    document.getElementById("todo-task"),
    document.getElementById("inprogress-task"),
    document.getElementById("complete-task"),
  ],
  {
    moves: function (el, container, handle) {
      console.log(el, container, handle);
      return handle.classList.contains("move-item");
    },
  }
);
