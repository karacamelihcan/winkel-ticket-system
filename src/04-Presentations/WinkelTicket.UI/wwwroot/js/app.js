(function ($) {
  "use strict";

  function initMetisMenu() {
    //metis menu
    $("#side-menu").metisMenu();
  }

  function initLeftMenuCollapse() {
    $("#vertical-menu-btn").on("click", function (event) {
      event.preventDefault();
      $("body").toggleClass("sidebar-enable");
      if ($(window).width() >= 992) {
        $("body").toggleClass("vertical-collpsed");
      } else {
        $("body").removeClass("vertical-collpsed");
      }
    });

    $("body,html").click(function (e) {
      var container = $("#vertical-menu-btn");
      if (
        !container.is(e.target) &&
        container.has(e.target).length === 0 &&
        !e.target.closest("div.vertical-menu")
      ) {
        $("body").removeClass("sidebar-enable");
      }
    });
  }

  function initActiveMenu() {
    // === following js will activate the menu in left side bar based on url ====
    $("#sidebar-menu a").each(function () {
      var pageUrl = window.location.href.split(/[?#]/)[0];
      if (this.href == pageUrl) {
        $(this).addClass("active");
        $(this).parent().addClass("mm-active"); // add active to li of the current link
        $(this).parent().parent().addClass("mm-show");
        $(this).parent().parent().prev().addClass("mm-active"); // add active class to an anchor
        $(this).parent().parent().parent().addClass("mm-active");
        $(this).parent().parent().parent().parent().addClass("mm-show"); // add active to li of the current link
        $(this)
          .parent()
          .parent()
          .parent()
          .parent()
          .parent()
          .addClass("mm-active");
      }
    });
  }

  function initMenuItem() {
    $(".navbar-nav a").each(function () {
      var pageUrl = window.location.href.split(/[?#]/)[0];
      if (this.href == pageUrl) {
        $(this).addClass("active");
        $(this).parent().addClass("active");
        $(this).parent().parent().addClass("active");
        $(this).parent().parent().parent().addClass("active");
        $(this).parent().parent().parent().parent().addClass("active");
        $(this).parent().parent().parent().parent().parent().addClass("active");
      }
    });
  }

  function initMenuItemScroll() {
    // focus active menu in left sidebar
    $(document).ready(function () {
      if (
        $("#sidebar-menu").length > 0 &&
        $("#sidebar-menu .mm-active .active").length > 0
      ) {
        var activeMenu = $("#sidebar-menu .mm-active .active").offset().top;
        if (activeMenu > 300) {
          activeMenu = activeMenu - 300;
          $(".vertical-menu .simplebar-content-wrapper").animate(
            { scrollTop: activeMenu },
            "slow"
          );
        }
      }
    });
  }

  function initDropdownMenu() {
    if (document.getElementById("topnav-menu-content")) {
      var elements = document
        .getElementById("topnav-menu-content")
        .getElementsByTagName("a");
      for (var i = 0, len = elements.length; i < len; i++) {
        elements[i].onclick = function (elem) {
          if (elem.target.getAttribute("href") === "#") {
            elem.target.parentElement.classList.toggle("active");
            elem.target.nextElementSibling.classList.toggle("show");
          }
        };
      }
      window.addEventListener("resize", updateMenu);
    }
  }

  function updateMenu() {
    var elements = document
      .getElementById("topnav-menu-content")
      .getElementsByTagName("a");
    for (var i = 0, len = elements.length; i < len; i++) {
      if (
        elements[i].parentElement.getAttribute("class") ===
        "nav-item dropdown active"
      ) {
        elements[i].parentElement.classList.remove("active");
        elements[i].nextElementSibling.classList.remove("show");
      }
    }
  }

  function initComponents() {
    // Tooltip
    var tooltipTriggerList = [].slice.call(
      document.querySelectorAll('[data-bs-toggle="tooltip"]')
    );
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
      return new bootstrap.Tooltip(tooltipTriggerEl);
    });

    // Popover
    var popoverTriggerList = [].slice.call(
      document.querySelectorAll('[data-bs-toggle="popover"]')
    );
    var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
      return new bootstrap.Popover(popoverTriggerEl);
    });
  }

  function initPreloader() {
    $(window).on("load", function () {
      $("#status").fadeOut();
      $("#preloader").delay(350).fadeOut("slow");
    });
  }

  function init() {
    initMetisMenu();
    initLeftMenuCollapse();
    initActiveMenu();
    initMenuItem();
    initMenuItemScroll();
    initDropdownMenu();
    initComponents();
    initPreloader();
    Waves.init();
  }

  $(document).ready(function () {
    init();
  });
})(jQuery);
