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
                    getNewMonth(this.getAttribute('data-new-month'), this.className.substr(this.className.indexOf('-') + 1));
                    this.disabled = true;
                }, false);
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

        function getNewMonth(route, arrowDir) {
            var request = new XMLHttpRequest();
            request.open('GET', '/events/getmonth/' + route, true);

            request.onload = function () {
                if (request.status >= 200 && request.status < 400) {
                    var resp = request.responseText;
                    if (resp) {
                        var newCalendar = document.createElement('div');
                        newCalendar.classList.add('calendar-container');

                        if (arrowDir == 'left') {
                            newCalendar.classList.add('pre-left');
                            mainContent.appendChild(newCalendar);
                            newCalendar.innerHTML = resp;
                            mainContent.children[0].classList.add('post-left');

                            window.setTimeout(function () {
                                mainContent.children[1].classList.remove('pre-left');
                            }, 25);
                        } else {
                            newCalendar.classList.add('pre-right');
                            mainContent.appendChild(newCalendar);
                            newCalendar.innerHTML = resp;
                            mainContent.children[0].classList.add('post-right');

                            window.setTimeout(function () {
                                mainContent.children[1].classList.remove('pre-right');
                            }, 25);
                        }

                        window.setTimeout(function () {
                            mainContent.removeChild(mainContent.children[0]);
                            app.addArrowListeners();
                        }, 500);
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