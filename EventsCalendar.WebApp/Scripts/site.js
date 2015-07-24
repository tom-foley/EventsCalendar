(function () {
    'use strict';

    window.siteJs = function () {
        var app = this;
        var nav, drawer, drawerBtn, drawerActive;
        var body, mainContent;

        app.post = function () {

        }

        app.get = function () {

        }

        app.loadPage = function () {
            nav = document.getElementById('nav');
            drawer = document.getElementById('drawer');
            drawerBtn = document.getElementById('drawer-btn');
            drawerActive = false;
            body = document.body;
            mainContent = document.getElementsByClassName('main-content')[0];
        }

        app.addEventListeners = function () {
            drawerBtn.addEventListener('click', function () {
                toggleSidenav();
            }, false);
        }

        app.init = function () {
            this.loadPage();
            this.addEventListeners();
        }

        app.init();

        function toggleSidenav() {
            if (!drawerActive) {
                drawer.classList.add('active');
                drawerActive = true;
            } else {
                drawer.classList.remove('active');
                drawerActive = false;
            }
        }
    }

})();

var siteJs = new siteJs();