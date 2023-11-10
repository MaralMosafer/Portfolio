$.fn.DeeboProgressIsInViewport = function(content) {
	"use strict";
	return $(this).offset().top - content.outerHeight();
};
/*
 * Copyright (c) 2021 Frenify
 * Author: Frenify
 * This file is made for CURRENT TEMPLATE
*/


(function($){
  "use strict";
  
  
	var FrenifyDeebo = {

		init: function(){
			FrenifyDeebo.BgImg();
			FrenifyDeebo.imgToSVG();
			FrenifyDeebo.progress();
			FrenifyDeebo.resume();
			FrenifyDeebo.loadBlogPosts();
			FrenifyDeebo.modal();
			FrenifyDeebo.progress2();
			FrenifyDeebo.contactForm();
			FrenifyDeebo.toTopJumper();
			FrenifyDeebo.rating();
			FrenifyDeebo.isotope();
			FrenifyDeebo.portfolioFilter();
			FrenifyDeebo.magnific();
			FrenifyDeebo.anchor();
			FrenifyDeebo.darklight();
		},
		
		darklight: function(){
			$('.deebo_fn_switcher_wrap input').on('change',function(){
				var checkBox = $(this);
				if(checkBox.is(':checked')){
					setTimeout(function(){
						window.open('index.html', "_self");
					},500);
				}else{
					setTimeout(function(){
						window.open('index-light.html', "_self");
					},500);
				}
				return false;
			});
		},
		
		anchor: function(){

			$('.anchor').on('click',function(){
				var selector = '.cv__content';
				if($(window).width() <= 1040){
					selector = 'body,html';
				}
				if($.attr(this, 'href') !== '#'){
					$(selector).animate({
						scrollTop: $($.attr(this, 'href')).offset().top
					}, 800);
				}

				return false;
			});	
		},
		
		magnific: function(){
			$('.gallery_zoom').each(function() { // the containers for all your galleries
				$(this).magnificPopup({
					delegate: 'a.zoom', // the selector for gallery item
					type: 'image',
					gallery: {
					  enabled:true
					},
					removalDelay: 300,
					mainClass: 'mfp-fade'
				});

			});
			$('.popup-youtube, .popup-vimeo').each(function() { // the containers for all your galleries
				$(this).magnificPopup({
					disableOn: 700,
					type: 'iframe',
					mainClass: 'mfp-fade',
					removalDelay: 160,
					preloader: false,
					fixedContentPos: false
				});
			});

			$('.soundcloude_link').magnificPopup({
			  type : 'image',
			   gallery: {
				   enabled: true, 
			   },
			});	
		},
		
		portfolioFilter: function(){
			var filter		 = $('.fn_cs_portfolio .portfolio_filter ul');

			if(filter.length){
				// Isotope Filter 
				filter.find('a').on('click', function(){
					var element		= $(this);
					var selector 	= element.attr('data-filter');
					var list		= element.closest('.fn_cs_portfolio').find('.portfolio_list').children('ul');
					list.isotope({ 
						filter				: selector,
						animationOptions	: {
							duration			: 750,
							easing				: 'linear',
							queue				: false
						}
					});

					filter.find('a').removeClass('current');
					element.addClass('current');
					return false;
				});	
			}	
		},
		
		isotope: function(){
			$('.grid').masonry({
				itemSelector: '.grid-item',
			});	
		},
		
		
		rating: function(){
			$('.t_rating').each(function(){
				var e 		= $(this),
					stars 	= parseFloat(e.data('stars'));
				var a	= stars * 20;
				var b 	= 100 - a;
				e.find('.rating_regular').css({width: b + '%'});
				e.find('.rating_active').css({width: a + '%'});
			});
		},
		
		
		toTopJumper: function(){
			var totop		= $('.deebo_fn_totop');
			if(totop.length){
				totop.on('click', function(e) {
					e.preventDefault();		
					$("html, body").animate(
						{ scrollTop: 0 }, 'slow');
					return false;
				});
			}
		},
		
		
		fixedTotopScroll: function(){
			var totop			= $('.deebo_fn_totop');
			var height 			= 100;
			if(totop.length){
				if($('.cv__content').scrollTop() > height){
					totop.addClass('scrolled');
				}else{
					totop.removeClass('scrolled');
				}
			}
		},
		
		contactForm: function(){
			$('#send_message').on('click', function(){
				var form		= $('.section_contact .contact_form');
				var name 		= $("#name").val();
				var email 		= $("#email").val();
				var message 	= $("#message").val();
				var phone 		= $("#phone").val();
				var spanSuccess	= form.find(".success");
				var success     = spanSuccess.data('success');
				var emailto     = form.data('email');

				spanSuccess.empty();
				if(name === ''|| email === ''|| message === '' || emailto === '' || phone === ''){
					$('.empty_notice').slideDown(500).delay(2000).slideUp(500);
				}
				else{
					$.post(
						"modal/contact.php",
						{
							ajax_name: 		name,
							ajax_email: 	email,
							ajax_emailto: 	emailto,
							ajax_message: 	message,
							ajax_phone: 	phone
						}, function(data) {
							spanSuccess.append(data);
							if(spanSuccess.find(".contact_error").length){
								spanSuccess.slideDown(500).delay(2000).slideUp(500);		
							}else{
								spanSuccess.append("<span class='contact_success'>" + success + "</span>");
								spanSuccess.slideDown(500).delay(4000).slideUp(500);
							}
							if(data === ''){ form[0].reset();}
						}
					);
				}
				return false; 
			});
		},
		
		
		progress2: function(){
			$('.fn_cs_progress_bar').each(function() {
				var pWrap 	= $(this);
				pWrap.waypoint({handler: function(){FrenifyDeebo.progress2F(pWrap);},offset:'90%'});
			});
		},
		
		progress2F: function(container){
			container.find('.progress_item').each(function(i) {
				var progress 	= $(this);
				var pValue 		= parseInt(progress.data('value'));
				var percent 	= progress.find('.progress_percent');
				var pBar 		= progress.find('.progress_bg');
				pBar.css({width:pValue+'%'});
				setTimeout(function(){
					progress.addClass('open');
					percent.html(pValue+'%').css({right:(100 - pValue)+ '%'});
				},(i*500));
			});	
		},
		modal: function(){
			var self		= this;
			var modalBox	= $('.deebo_fn_modalbox');
			var item		= $('.modal_item');
			var closePopup	= modalBox.find('.closer,.extra_closer');
			var prevNext	= modalBox.find('.fn__nav');
			var extraCloser = modalBox.find('.extra_closer');
			extraCloser.on('mouseenter',function(){
				modalBox.addClass('hovered');
			}).on('mouseleave',function(){
				modalBox.removeClass('hovered');
			});
			item.on('click',function(){
				var element		= $(this);
				var content 	= element.find('.fn__hidden').html();
				
				
				var items		= element.closest('.modal_items'),
					index		= element.attr('data-index'),
					from		= items.attr('data-from');
				prevNext.attr('data-index',index);
				prevNext.attr('data-from',from);
				
				
				$('body').addClass('modal');
				modalBox.addClass('opened');
				modalBox.find('.modal_in').html(content);
				
				self.modal_prevnext(prevNext,modalBox);
				self.imgToSVG();
				self.BgImg();
				
				return false;
			});
			self.modal_prevnext(prevNext,modalBox);
			closePopup.on('click',function(){
				modalBox.removeClass('opened hovered');
				modalBox.find('.modal_in').html('');
				$('body').removeClass('modal');
				return false;
			});
		},
		
		modal_prevnext: function(prevNext,modalBox){
			var self		= this;
			prevNext.find('a').off().on('click',function(){
				var e		= $(this);
				var from 	= prevNext.attr('data-from');
				var index	= parseInt(prevNext.attr('data-index'));
				var itemss	= $('.modal_items[data-from="'+from+'"]');
				var count	= parseInt(itemss.attr('data-count'));
				if(e.hasClass('prev')){
					index--;
				}else{
					index++;
				}
				if(index < 1){index = count;}
				if(index > count){index = 1;}
				
				var content = itemss.find('.modal_item[data-index="'+index+'"] .fn__hidden').html();
				prevNext.removeClass('disabled');
				prevNext.attr('data-index',index);
				
				setTimeout(function(){
					modalBox.find('.modal_in').fadeOut(500, function() {
						$(this).html('').html(content).fadeIn(500);
					});
				},500);
					
				$(".deebo_fn_modalbox .modal_content").stop().animate({scrollTop:0}, 500, 'swing');
				
				self.modal_prevnext(prevNext,modalBox);
				self.imgToSVG();
				self.BgImg();
				return false;
			});
		},
		
		loadBlogPosts: function(){
			$('.section_tips .load_more a').on('mousedown',function(){
				var element 	= $(this);
				var text 		= element.find('.text');
				// stop function if don't have more items
				if(element.hasClass('done')){
					element.addClass('hold');
					text.text(element.attr('data-no'));
					return false;
				}
			}).on('mouseup',function(){
				var element 	= $(this);
				var text 		= element.find('.text');
				// stop function if don't have more items
				if(element.hasClass('done')){
					element.removeClass('hold');
					text.text(element.attr('data-done'));
					return false;
				}
			}).on('mouseleave',function(){
				var element 	= $(this);
				var text 		= element.find('.text');
				// stop function if don't have more items
				if(element.hasClass('done')){
					element.removeClass('hold');
					text.text(element.attr('data-done'));
					return false;
				}
			});
			$('.section_tips .load_more a').on('click',function(){
				var element 	= $(this);
				var text 		= element.find('.text');
				
				// stop function if elements are loading right now
				if(element.hasClass('loading') || element.hasClass('done')){return false;}
				element.addClass('loading');
				
				
				
				
				setTimeout(function(){
					var listItem = element.closest('.section_tips').find('.be_animated');
					listItem.each(function(i, e){
						setTimeout(function(){
							$(e).addClass('fadeInTop done');
						}, (i*100));	
					});
					element.addClass('done').removeClass('loading');
					text.text(element.attr('data-done'));
				},1500);
				
				
				return false;
			});
		},
		
		resume: function(){
			$('.deebo_fn__cv .cv__content').scrollTop(0);
			$('body').addClass('resume-opened');
		},
		
		progress: function(){
			var content = $('.deebo_fn__cv .cv__content');
			if($(window).width() <= 768){
				content = $('.deebo_fn__cv');
			}
			content.on('resize scroll', function() {
				if ($('.deebo_fn__cv .fn_cs_progress_bar').DeeboProgressIsInViewport(content) < 0) {
					FrenifyDeebo.progressF($('.deebo_fn__cv .fn_cs_progress_bar'));
				}
			});
		},
		
		progressF: function(container){
			container.find('.progress_item').each(function(i) {
				var progress 	= $(this);
				var pValue 		= parseInt(progress.data('value'));
				var percent 	= progress.find('.progress_percent');
				var pBar 		= progress.find('.progress_bg');
				pBar.css({width:pValue+'%'});
				setTimeout(function(){
					progress.addClass('open');
					percent.html(pValue+'%').css({right:(100 - pValue)+ '%'});
				},(i*500));
			});	
		},
		
		recallProgress: function(){
			var tabs = $('.fn_cs_progress_bar');
			tabs.find('.progress_bg').css({width:'0%'});
			tabs.find('.progress_percent').html('').css({right:'100%'});
			tabs.find('.progress_item').removeClass('open');
		},
		
		imgToSVG: function(){
			$('img.fn__svg').each(function(){
				var img 		= $(this);
				var imgClass	= img.attr('class');
				var imgURL		= img.attr('src');

				$.get(imgURL, function(data) {
					var svg 	= $(data).find('svg');
					if(typeof imgClass !== 'undefined') {
						svg 	= svg.attr('class', imgClass+' replaced-svg');
					}
					img.replaceWith(svg);

				}, 'xml');

			});	
		},

	  	BgImg: function(){
			var div = $('*[data-bg-img]');
			div.each(function(){
				var element = $(this);
				var attrBg	= element.attr('data-bg-img');
				var dataBg	= element.data('bg-img');
				if(typeof(attrBg) !== 'undefined'){
					element.css({backgroundImage:'url('+dataBg+')'});
				}
			});
		},
    
  	};
  	
	
	// READY Functions
	$(document).ready(function(){FrenifyDeebo.init();});
	
	// RESIZE Functions
	$(window).on('resize',function(){
		FrenifyDeebo.isotope();
		setTimeout(function(){
			FrenifyDeebo.isotope();
		},1010);
	});
	
	// LOAD Functions
	$(window).on('load',function(){
		
		setTimeout(function(){
			
		},10);
	});
	
	// SCROLL Functions
	$('.cv__content').on('scroll',function(){
		FrenifyDeebo.fixedTotopScroll();
	});
  	
})(jQuery);