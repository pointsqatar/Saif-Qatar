/*
Copyright (c) 2016 Kamleshyadav
------------------------------------------------------------------
[Master Javascript]

Project:	Fixit - Multipurpose Construction & Building HTML

-------------------------------------------------------------------*/

(function ($) {
    "use strict";
    var Fixit = {
        initialised: false,
        version: 1.0,
        mobile: false,
        init: function () {

            if (!this.initialised) {
                this.initialised = true;
            } else {
                return;
            }

            /*-------------- Fixit Functions Calling ---------------------------------------------------
			------------------------------------------------------------------------------------------------*/
            this.RTL();
            this.Navigation();
            this.GreenSock_animation();
            this.SelectToUl();
            this.Testimonials_slider();
            this.Blog_slider();
            this.Clients_slider();
            this.Sidebar();
            this.count_number();
            this.ourservice_animation();
            this.project_gallery_slider();
            this.project_slider();
            this.playYoutubeVideo();
            this.Filterable_project();
            this.coming_soon_timer();
            this.Parallax();
            this.Splash_demo();

            this.Subscribe_AjaxMail();
            this.Contact_AjaxMail();


        },

        /*-------------- Fixit Functions definition ---------------------------------------------------
		---------------------------------------------------------------------------------------------------*/
        RTL: function () {
            // On Right-to-left(RTL) add class 
            var rtl_attr = $("html").attr('dir');
            if (rtl_attr) {
                $('html').find('body').addClass("rtl");
            }
        },
        Navigation: function () {
            //menu scroll fixed
            $(window).bind('scroll', function () {
                if ($(window).scrollTop() > 70) {
                    $('.fixit_header').addClass('fixed_menu');
                } else {
                    $('.fixit_header').removeClass('fixed_menu');
                }
            });

            // mobile toggle menu
            $('.fixit_menu_toggle').on('click', function () {
                $(this).toggleClass('toggle_open');
                $('.fixit_header_center').toggleClass('mob_open_menu');
            });

            // check dropdown is visible or not 
            $('.fixit_header .fixit_menu > ul li').has('ul').addClass('fixit_dropdown');

        },
        Home1_slider: function () {

            if ($("#rev_slider_4_1").length > 0) {
                var revapi4 = $("#rev_slider_4_1").show().revolution({
                    sliderType: "standard",
                    jsFileLocation: "../../revolution/js/",
                    sliderLayout: "fullwidth",
                    dottedOverlay: "none",
                    delay: 9000,
                    navigation: {
                        keyboardNavigation: "off",
                        keyboard_direction: "horizontal",
                        mouseScrollNavigation: "off",
                        onHoverStop: "off",
                        touch: {
                            touchenabled: "on",
                            swipe_threshold: 75,
                            swipe_min_touches: 1,
                            swipe_direction: "horizontal",
                            drag_block_vertical: false
                        }
						,
                        arrows: {
                            style: "zeus",
                            enable: true,
                            hide_onmobile: true,
                            hide_under: 840,
                            hide_onleave: true,
                            hide_delay: 200,
                            hide_delay_mobile: 1200,
                            tmp: '<div class="tp-title-wrap">  	<div class="tp-arr-imgholder"></div> </div>',
                            left: {
                                h_align: "left",
                                v_align: "center",
                                h_offset: 30,
                                v_offset: 0
                            },
                            right: {
                                h_align: "right",
                                v_align: "center",
                                h_offset: 30,
                                v_offset: 0
                            }
                        }
						,
                        bullets: {
                            enable: false
                        }
                    },
                    viewPort: {
                        enable: true,
                        outof: "pause",
                        visible_area: "80%"
                    },
                    responsiveLevels: [1240, 1024, 778, 480],
                    gridwidth: [1240, 1024, 778, 480],
                    gridheight: [840, 740, 640, 400],
                    lazyType: "none",
                    parallax: {
                        type: "mouse",
                        origo: "slidercenter",
                        speed: 2000,
                        levels: [2, 3, 4, 5, 6, 7, 12, 16, 10, 50],
                    },
                    shadow: 0,
                    spinner: "off",
                    stopLoop: "off",
                    stopAfterLoops: -1,
                    stopAtSlide: -1,
                    shuffle: "off",
                    autoHeight: "off",
                    hideThumbsOnMobile: "off",
                    hideSliderAtLimit: 0,
                    hideCaptionAtLimit: 0,
                    hideAllCaptionAtLilmit: 0,
                    debugMode: false,
                    fallbacks: {
                        simplifyAll: "off",
                        nextSlideOnWindowFocus: "off",
                        disableFocusListener: false,
                    }
                });
            }

            //slider button hover
            $('.fixit_slider_btngroup a.call').hover(function () {
                $('.fixit_slider_btngroup span').css('left', '0%');
            });
            $('.fixit_slider_btngroup a.call').mouseenter(function () {
                $(this).addClass('active');
                $('.fixit_slider_btngroup a.readmore').removeClass('active');
            }).mouseleave(function () {
                $(this).removeClass('active');
            });


            $('.fixit_slider_btngroup a.readmore').hover(function () {
                $('.fixit_slider_btngroup span').css('left', '50%');
            });
            $('.fixit_slider_btngroup a.readmore').mouseenter(function () {
                $(this).addClass('active');
                $('.fixit_slider_btngroup a.call').removeClass('active');
                $('.fixit_slider_btngroup span').css('width', '50%');
            }).mouseleave(function () {
                $(this).removeClass('active');
                $('.fixit_slider_btngroup span').css('width', '55%');
            });


            $('.fixit_slider_btngroup').mouseleave(function () {
                $('.fixit_slider_btngroup span').css('left', '0%');
                $(this).children('a.call').addClass('active');
            });

        },
        GreenSock_animation: function () {

            var controller = $.superscrollorama({
                triggerAtCenter: true,
                playoutAnimations: true
            });

            // amount of scrolling over which the tween takes place (in pixels)
            var scrollDuration = 0;


            // service order right image
            controller.addTween('.fixit_services', TweenMax.from($('.fixit_sow_image'), 1.2, { opacity: 0, x: 100, ease: Power4.easeInOut, y: 0 }), scrollDuration);
            controller.addTween('.fixit_services', TweenMax.to($('.fixit_sow_image'), 1.2, { opacity: 1, x: 0, ease: Power4.easeInOut, y: 0 }), scrollDuration);


            // price table
            controller.addTween('.fixit_price_section', TweenMax.from($('.fixit_price_wrapper'), 2, { opacity: 0, rotationX: 45, transformPerspective: 500, transformOrigin: "50% 100%", ease: Power4.easeInOut, y: 0 }), scrollDuration);
            controller.addTween('.fixit_price_section', TweenMax.to($('.fixit_price_wrapper'), 2, { opacity: 1, rotationX: 0, transformPerspective: 100, transformOrigin: "50% 100%", ease: Power4.easeInOut, y: 0 }), scrollDuration);

            controller.addTween('.fixit_price_section', TweenMax.from($('.fixit_price_wrapper.active'), 1, { opacity: 0, rotationX: 25, transformPerspective: 500, transformOrigin: "50% 100%", ease: Power4.easeInOut, y: 0 }), scrollDuration);
            controller.addTween('.fixit_price_section', TweenMax.to($('.fixit_price_wrapper.active'), 1, { opacity: 1, rotationX: 0, transformPerspective: 100, transformOrigin: "50% 100%", ease: Power4.easeInOut, y: 0 }), scrollDuration);


            // team member
            controller.addTween('.fixit_team_section', TweenMax.from($('.fixit_team_wrapper.anim_come1'), 1, { opacity: 0, y: 80, ease: Power4.easeInOut }), scrollDuration);
            controller.addTween('.fixit_team_section', TweenMax.to($('.fixit_team_wrapper.anim_come1'), 1, { opacity: 1, y: 0, ease: Power4.easeInOut }), scrollDuration);

            controller.addTween('.fixit_team_section', TweenMax.from($('.fixit_team_wrapper.anim_come2'), 1.2, { opacity: 0, y: 120, ease: Power4.easeInOut }), scrollDuration);
            controller.addTween('.fixit_team_section', TweenMax.to($('.fixit_team_wrapper.anim_come2'), 1.2, { opacity: 1, y: 0, ease: Power4.easeInOut }), scrollDuration);

            controller.addTween('.fixit_team_section', TweenMax.from($('.fixit_team_wrapper.anim_come3'), 1.4, { opacity: 0, y: 160, ease: Power4.easeInOut }), scrollDuration);
            controller.addTween('.fixit_team_section', TweenMax.to($('.fixit_team_wrapper.anim_come3'), 1.4, { opacity: 1, y: 0, ease: Power4.easeInOut }), scrollDuration);

            controller.addTween('.fixit_team_section', TweenMax.from($('.fixit_team_wrapper.anim_come4'), 1.6, { opacity: 0, y: 200, ease: Power4.easeInOut }), scrollDuration);
            controller.addTween('.fixit_team_section', TweenMax.to($('.fixit_team_wrapper.anim_come4'), 1.6, { opacity: 1, y: 0, ease: Power4.easeInOut }), scrollDuration);

            //Why we are the best?
            controller.addTween('.whywe_arethe_best h3.wwa_title', TweenMax.from($('.wwa_service'), 1, { opacity: 0, x: 80, ease: Power4.easeInOut }), scrollDuration);
            controller.addTween('.whywe_arethe_best h3.wwa_title', TweenMax.to($('.wwa_service'), 1, { opacity: 1, x: 0, ease: Power4.easeInOut }), scrollDuration);

            controller.addTween('.whywe_arethe_best h3.wwa_title', TweenMax.from($('.wwa_service.right_align'), 1, { opacity: 0, x: -80, ease: Power4.easeInOut }), scrollDuration);
            controller.addTween('.whywe_arethe_best h3.wwa_title', TweenMax.to($('.wwa_service.right_align'), 1, { opacity: 1, x: 0, ease: Power4.easeInOut }), scrollDuration);



        },
        SelectToUl: function () {
            if ($('.fixit_select_dropdown').length > 0) {
                $('.fixit_select_dropdown').selectpicker({
                    style: 'null',
                    size: 4,
                    showIcon: false
                });
            }

        },
        Testimonials_slider: function () {
            if ($('.fixit_testimonials_slider').length > 0) {
                $('.fixit_testimonials_slider').owlCarousel({
                    animateOut: 'fadeOutLeft',
                    animateIn: 'fadeInRight',
                    loop: true,
                    autoplay: true,
                    autoplayTimeout: 3000,
                    items: 1,
                    dots: true,
                    margin: 30,
                    stagePadding: 30,
                    smartSpeed: 450,
                    mouseDrag: false
                });
            }
        },
        Blog_slider: function () {
            if ($('.fixit_ourblog_slider').length > 0) {
                $('.fixit_ourblog_slider').owlCarousel({
                    items: 3,
                    dots: false,
                    nav: true,
                    margin: 30,
                    stagePadding: 0,
                    smartSpeed: 450,
                    navText: ['', ''],
                    responsive: {
                        0: {
                            items: 1
                        },
                        700: {
                            items: 2
                        },
                        1024: {
                            items: 2
                        },
                        1200: {
                            items: 3
                        },
                        1480: {
                            items: 3
                        }
                    }
                });
            }
        },
        Clients_slider: function () {
            if ($('.fixit_ourclients_slider').length > 0) {
                $('.fixit_ourclients_slider').owlCarousel({
                    animateOut: 'fadeOutLeft',
                    animateIn: 'fadeInRight',
                    loop: true,
                    autoplay: true,
                    autoplayTimeout: 3000,
                    items: 6,
                    dots: true,
                    margin: 30,
                    stagePadding: 30,
                    smartSpeed: 450,
                    mouseDrag: false,
                    responsive: {
                        0: {
                            items: 3
                        },
                        700: {
                            items: 4
                        },
                        1024: {
                            items: 6
                        },
                        1200: {
                            items: 6
                        },
                        1480: {
                            items: 6
                        }
                    }
                });
            }
        },
        Sidebar: function () {
            if ($('#fixit_calendar_picker').length > 0) {
                $('#fixit_calendar_picker').datetimepicker({
                    yearOffset: 0,
                    inline: true,
                    timepicker: false,
                    todayButton: false,
                    scrollMonth: false,
                    scrollInput: false,
                    dayOfWeekStart: 1

                });
            }
        },
        pageLoader: function () {
            jQuery("#status").fadeOut();
            jQuery("#preloader").delay(350).fadeOut("slow");
        },
        count_number: function () {
            if ($('.appear-count').length > 0) {
                $('.appear-count').appear(function () {
                    $('.count').countTo();
                });
            }
        },
        ourservice_animation: function () {
            $(window).bind('scroll', function () {
                if ($(window).scrollTop() > 150) {
                    $('.fixit_ourservice').addClass('play');
                }
            });
        },
        project_gallery_slider: function () {
            if ($('.project_gallery_slider').length > 0) {
                $('.project_gallery_slider').owlCarousel({
                    autoplay: true,
                    autoplayTimeout: 3000,
                    items: 3,
                    dots: false,
                    nav: true,
                    navText: ['', ''],
                    margin: 0,
                    stagePadding: 0,
                    smartSpeed: 450,
                    mouseDrag: false,
                    responsive: {
                        0: {
                            items: 1
                        },
                        700: {
                            items: 2
                        },
                        1024: {
                            items: 2
                        },
                        1200: {
                            items: 3
                        },
                        1480: {
                            items: 3
                        }
                    }
                });
            }
        },
        project_slider: function () {
            if ($('.image_wrapper.slider').length > 0) {
                $('.image_wrapper.slider').owlCarousel({
                    items: 1,
                    dots: false,
                    nav: true,
                    navText: ['', ''],
                    margin: 0,
                    stagePadding: 0,
                    smartSpeed: 450,
                    mouseDrag: false,
                });
            }
        },
        playYoutubeVideo: function () {
            $('.image_wrapper.video .play_btn').on('click', function (ev) {
                $(this).parent().css('opacity', '0');
                $(this).parent().css('visibility', 'hidden');
                $(this).parent().prev().prev('img').css('opacity', '0');
                $(this).parent().prev().prev('img').css('visibility', 'hidden');

                $(this).parent().prev().children('iframe')[0].src += "&autoplay=1";
                ev.preventDefault();
            });
        },
        Filterable_project: function () {
            if ($('.fixit_grid').length > 0) {
                var $grid = $('.fixit_grid');
                $grid.isotope({
                    itemSelector: '.grid-item',
                    layoutMode: 'fitRows'
                });

                $('#project_filters a').on('click', function () {
                    event.preventDefault();
                    var filterValue = $(this).attr('data-filter');
                    $grid.isotope({ filter: filterValue });

                    $('#project_filters a').removeClass('active');
                    $(this).addClass('active');
                });
            }


        },
        coming_soon_timer: function () {
            // timer countdown
            $('[data-countdown]').each(function () {
                var $this = $(this), finalDate = $(this).data('countdown');
                $this.countdown(finalDate, function (event) {
                    $this.html(event.strftime('<div class="fixit_counter"><span><p class="number">%D</p> <p>Days</p></span> <span><p class="number">%H</p> <p>Hours</p></span> <span><p class="number">%M</p> <p>Minutes</p></span> <span><p class="number">%S</p> <p>Seconds</p></span></div>'));
                });
            });
        },
        Parallax: function () {
            // $('#scene').parallax();
        },
        Splash_demo: function () {
            var slider_h = $('.fixit_main_slider').innerHeight();
            var scrolled = 0;
            $('#fixit_scroll_to_demo').on('click', function () {
                scrolled = scrolled + slider_h + 200;
                $('body').animate({
                    scrollTop: scrolled
                });
                scrolled = 0;
            });
        },
        Subscribe_AjaxMail: function () {
            //Subscribe form submition
            $('#subscribe_email').keypress(function (e) {
                var key = e.which;
                if (key == 13)  // the enter key code
                {
                    $('#subscribe_form_submit').click();
                    return false;
                }
            });

            $("#subscribe_form_submit").on("click", function () {
                var e = $("#subscribe_email").val();
                $.ajax({
                    type: "POST",
                    url: "subscribe_ajaxmail.php",
                    data: {
                        useremail: e
                    },
                    success: function (contact) {
                        var subscribe_error = contact.split("#");
                        if (subscribe_error[0] == "1") {
                            $("#subscribe_email").val("");
                            $("#err").html(subscribe_error[1]);
                            $(".subscribe_form .input_wrapper").addClass('success');
                            setTimeout(function () {
                                $(".subscribe_form .input_wrapper").removeClass('success');
                            }, 2500);
                            setTimeout(function () {
                                $(".subscribe_form .input_wrapper").removeClass('error');
                            }, 2000);
                        } else {
                            $("#subscribe_email").val(e);
                            $("#err").html(subscribe_error[1]);
                            $(".subscribe_form .input_wrapper").addClass('error');
                            setTimeout(function () {
                                $(".subscribe_form .input_wrapper").removeClass('error');
                            }, 2000);

                        }
                    }
                })
            });

        },
        Contact_AjaxMail: function () {
            //contact form submition
            $('#cont_msg').keypress(function (e) {
                var key = e.which;
                if (key == 13)  // the enter key code
                {
                    $('#contact_form_submit[name = contact_form_submit_name]').click();
                    return false;
                }
            });

            var form = $('#sendmessageform');

            $("#contact_form_submit[name='contact_form_submit_name']").on("click", function () {
                var form_status = $('<div class="form_status"></div>');
                var baseurl = location.protocol + "//" + location.hostname + (location.port && ":" + location.port) + "/";
                var co_name = $("#cont_name").val();
                var co_email = $("#cont_email").val();
                var co_subject = $("#cont_subject").val();
                var co_company = $("#cont_company").val();
                var co_message = $("#cont_msg").val();
                $.ajax({
                    type: "POST",
                    url: baseurl + 'mail/sendmail',
                    data: {
                        username: co_name,
                        usermailid: co_email,
                        usersubject: co_subject,
                        usercmpyname: co_company,
                        usermessage: co_message
                    },
                    beforeSend: function () {
                        form.prepend(form_status.html('<p><i class="fa fa-spinner fa-spin"></i> Email is sending...</p>').fadeIn());
                    },
                    success: function (result) {
                        //var i = contact.split("#");
                        if (result == "success") {
                            $("#cont_name").val("");
                            $("#cont_email").val("");
                            $("#cont_subject").val("");
                            $("#cont_company").val("");
                            $("#cont_msg").val("");
                            //$("#contact_err").html(i[1]);

                            $(".post_add_comment_wrapper .input_wrapper").addClass('success');
                            setTimeout(function () {
                                $(".post_add_comment_wrapper .input_wrapper").removeClass('success');
                                $(".post_add_comment_wrapper .input_wrapper").removeClass('error');
                                $("#cont_email").parent().removeClass('error');
                            }, 2500);
                        }
                        else {
                            $("#cont_name").val(co_name);
                            $("#cont_email").val(co_email);
                            $("#cont_subject").val(co_subject);
                            $("#cont_company").val(co_company);
                            $("#cont_msg").val(co_message);
                            //$("#contact_err").html(i[1]);
                            $(".post_add_comment_wrapper .input_wrapper input, .post_add_comment_wrapper .input_wrapper textarea").each(function () {
                                if (!$(this).val()) {
                                    $(this).parent().addClass('error');
                                } else {
                                    if (result == "failed") {
                                        $("#cont_email").parent().addClass('error');
                                    }
                                    else {
                                        $(this).parent().addClass('error');
                                    }
                                    $(this).parent().removeClass('error');
                                }
                            });
                        }

                        form_status.html('<p class="text-success">' + result + '</p>').delay(3000).fadeOut();
                    }
                })
            });

            $(".post_add_comment_wrapper .input_wrapper input, .post_add_comment_wrapper .input_wrapper textarea").keypress(function () {
                $(this).parent().removeClass('error');
            });


        }




    };

    Fixit.init();

    // Load Event
    $(window).on('load', function () {
        /* Trigger side menu scrollbar */
        //Fixit.menuScrollbar();

        //page loader
        Fixit.pageLoader();

        //home3 content loaded
        setTimeout(function () {
            $('.fixit_slider_content').addClass('loaded');
        }, 500);

    });

    // Scroll Event
    $(window).on('scroll', function () {

    });

    // ready function
    $(document).ready(function () {
        Fixit.Home1_slider();
    });


})(jQuery);
