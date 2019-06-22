/************ CSS Styles ************

    Template Name:  Cukur - Digital Agency Template
    Author: kholie-b
    version: 1.0
    Copyright: 2019

************************************/

/*==================================

        Table of Content

        1. Preloader
        2. Navigation
        3. Introduction
        4. About
        5. Skills
		6. Team
        7. Testimonials
        8. Work
        9. Numbers
        10. Blog
      
==================================*/

/*global $*/

$(function () {

	"use strict";
	var win = $(window),
		navbar = $('.navbar'),
		scrollUp = $(".scroll-up");
	/*----------------------------------------------------------------
						1. Preloader
	----------------------------------------------------------------*/
	$('.preloader').delay(200).fadeOut('slow');
	setTimeout(function () {
		//After 2s, the preloader class of the body will be removed
		$('body').removeClass('preloader');
	}, 500);
	/*----------------------------------------------------------------
						2. Navigation
	----------------------------------------------------------------*/
	/*========== Start Navbar Auto Change  ==========*/
	win.on('scroll', function () {
		if (win.scrollTop() > 50) {
			navbar.addClass('nav-fixed').removeClass('fixed-top');
		} else {
			navbar.addClass('fixed-top').removeClass('nav-fixed');
		}
	});

	/*========== Start Scroll For Navigation Menu ==========*/
	navbar.on('click', 'a', function (e) {
		e.preventDefault();
		var $anchor = $(this);
		$('html, body').stop().animate({
			scrollTop: $($anchor.attr('href')).offset().top - 68
		}, 1000);
	});

	// Sync Navbar Links With Section
	$('body').scrollspy({
		target: '#navtoggler',
		offset: 82
	});
	//// COLLAPSED MENU CLOSE ON CLICK
	navbar.on('click', '.navbar-collapse', function (e) {
		if ($(e.target).is('a')) {
			$(this).collapse('hide');
		}
	});
	/*========== Scroll on click to Introduction Section  ==========*/
	$('.drop-down a').on('click', function (e) {
		e.preventDefault();
		var $anchor = $(this);
		$('html, body').stop().animate({
			scrollTop: $($anchor.attr('href')).offset().top - 68
		}, 1000);
	});
	/*----------------------------------------------------------------
						3. Introduction
	----------------------------------------------------------------*/
	$(".introduction .owl-carousel").owlCarousel({
		items: 3,
		autoplay: true,
		smartSpeed: 500,
		margin: 30,
		loop: true,
		autoplayHoverPause: true,
		responsive: {
			0: {
				items: 1
			},
			768: {
				items: 2
			},
			999: {
				items: 3
			}
		}
	});
	/*----------------------------------------------------------------
						4. About
	----------------------------------------------------------------*/
	$(".about .owl-carousel").owlCarousel({
		items: 1,
		autoplay: true,
		smartSpeed: 600,
		margin: 30,
		loop: true,
		autoplayHoverPause: true
	});
	/*----------------------------------------------------------------
						5. Skills
	----------------------------------------------------------------*/
	$('.popup-video').magnificPopup({

		disableOn: 10,
		type: 'iframe',
		mainClass: 'mfp-fade',
		removalDelay: 160,
		preloader: false,
		fixedContentPos: false
	});
	/*----------------------------------------------------------------
						6. Team
	----------------------------------------------------------------*/
	$(".team .owl-carousel").owlCarousel({
		items: 3,
		autoplay: true,
		smartSpeed: 500,
		margin: 30,
		loop: true,
		autoplayHoverPause: true,
		responsive: {
			0: {
				items: 1
			},
			768: {
				items: 2
			},
			999: {
				items: 3
			}
		}
	});
	/*----------------------------------------------------------------
						7. Testimonials
	----------------------------------------------------------------*/
	$(".testimonials .owl-carousel").owlCarousel({
		items: 1,
		autoplay: true,
		smartSpeed: 500,
		margin: 30,
		loop: true,
		autoplayHoverPause: true
	});
	/*----------------------------------------------------------------
						8. Work
	----------------------------------------------------------------*/
	/*Work Section Filter*/
	$("#control li").on('click', function () {
		$(this).addClass('active').siblings().removeClass('active');
	});
	// The Filterizr
	$('#filtr-container').filterizr({
		animationDuration: 0.4
	});
	$('.work-inner .title').magnificPopup({
		delegate: 'a',
		type: 'image',
		gallery: {
			enabled: true
		}
	});
	/*----------------------------------------------------------------
						9. Numbers
	----------------------------------------------------------------*/
	$('.counter').counterUp({
		delay: 100,
		time: 2000
	});
	/*----------------------------------------------------------------
						10. Blog
	----------------------------------------------------------------*/
	$(".blog .owl-carousel").owlCarousel({
		items: 3,
		autoplay: true,
		smartSpeed: 500,
		margin: 30,
		loop: true,
		autoplayHoverPause: true,
		responsive: {
			0: {
				items: 1
			},
			768: {
				items: 2
			},
			999: {
				items: 3
			}
		}
	});
});
