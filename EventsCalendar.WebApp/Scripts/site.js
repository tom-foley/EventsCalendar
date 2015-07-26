(function () {
    'use strict';

    window.siteJs = function () {
        var app = this;
        var nav, drawer, drawerBtn, drawerActive;
        var body, mainContent, arrows;

        app.post = function () {

        }

        app.get = function (route) {

        }

        app.loadPage = function () {
            nav = document.getElementById('nav');
            drawer = document.getElementById('drawer');
            drawerBtn = document.getElementById('drawer-btn');
            drawerActive = false;
            body = document.body;
            mainContent = document.getElementsByClassName('main-content')[0];
            arrows = document.getElementsByClassName('arrow');
        }

        app.addDrawerListener = function () {
            drawerBtn.addEventListener('click', function () {
                toggleSidenav();
            }, false);
        }

        app.addArrowListeners = function () {
            for (var i = 0; i < arrows.length; i++) {
                arrows[i].addEventListener('click', function () {
                    getNewMonth(this.getAttribute('data-new-month'));
                }, false)
            }
        }

        app.init = function () {
            this.loadPage();
            this.addDrawerListener();
            this.addArrowListeners();
        }

        app.init();

        function toggleSidenav() {
            console.log(drawerActive);
            if (!drawerActive) {
                drawer.classList.add('active');
                drawerActive = true;
            } else {
                drawer.classList.remove('active');
                drawerActive = false;
            }
        }

        function getNewMonth(route) {
            var request = new XMLHttpRequest();
            request.open('GET', '/events/getmonth/' + route, true);

            request.onload = function () {
                if (request.status >= 200 && request.status < 400) {
                    var resp = request.responseText;
                    if (resp) {
                        mainContent.innerHTML = resp;
                        app.addArrowListeners();
                    }
                } else {
                    // We reached our target server, but it returned an error
                }
            };

            request.onerror = function () {
                // There was a connection error of some sort
            };

            request.send();
        }
    }
})();

var siteJs = new siteJs();