jQuery(document).ready(function($) {

	'use strict';
    //***************************
    // Sticky Header Function
    //***************************
	  jQuery(window).scroll(function() {
	      if (jQuery(this).scrollTop() > 170){  
	          jQuery('body').addClass("wm-sticky");
	      }
	      else{
	          jQuery('body').removeClass("wm-sticky");
	      }
	  });

    //***************************
    // BannerOne Functions
    //***************************
    jQuery('.wm-banner-one-for').slick({
          slidesToShow: 1,
          slidesToScroll: 1,
          arrows: false,
          fade: true,
          asNavFor: '.wm-banner-one-nav'
        });
        jQuery('.wm-banner-one-nav').slick({
          slidesToShow: 3,
          slidesToScroll: 1,
          asNavFor: '.wm-banner-one-for',
          dots: false,
          vertical: true,
          prevArrow: "<span class='slick-arrow-left'><i class='wmicon-arrows'></i></span>",
          nextArrow: "<span class='slick-arrow-right'><i class='wmicon-arrows'></i></span>",
          centerMode: false,
          focusOnSelect: true,
          responsive: [
                {
                  breakpoint: 1024,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: true,
                    vertical: true,
                  }
                },
                {
                  breakpoint: 800,
                  settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                    vertical: true,
                  }
                },
                {
                  breakpoint: 1400,
                  settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                    vertical: true,
                  }
                },
                {
                  breakpoint: 1920,
                  settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                    vertical: true,
                  }
                },
                {
                  breakpoint: 400,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    vertical: true,
                  }
                }
              ],
        });
    //***************************
    // LatestEvent Functions
    //***************************
      jQuery('.wm-banner-three').slick({
          slidesToShow: 1,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          infinite: true,
          dots: true,
          arrows: false,
          fade: true,
          responsive: [
                {
                  breakpoint: 1024,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: true,
                  }
                },
                {
                  breakpoint: 800,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                },
                {
                  breakpoint: 400,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                }
              ]
        });

    //***************************
    // LatestEvent Functions
    //***************************
      jQuery('.wm-event-latest-slider').slick({
          slidesToShow: 1,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          infinite: true,
          prevArrow: "<span class='slick-arrow slick-arrow-left'><i class='wmicon-arrows4'></i></span>",
          nextArrow: "<span class='slick-arrow slick-arrow-right'><i class='wmicon-arrows4'></i></span>",
          responsive: [
                {
                  breakpoint: 1024,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: true,
                  }
                },
                {
                  breakpoint: 800,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                },
                {
                  breakpoint: 400,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                }
              ]
        });
    //***************************
    // Testimonial Functions
    //***************************
      jQuery('.wm-testimonial-slider').slick({
          slidesToShow: 2,
          slidesToScroll: 2,
          autoplay: true,
          autoplaySpeed: 5000,
          infinite: true,
          prevArrow: "<span class='slick-arrow slick-arrow-left'><i class='wmicon-arrows4'></i></span>",
          nextArrow: "<span class='slick-arrow slick-arrow-right'><i class='wmicon-arrows4'></i></span>",
          responsive: [
                {
                  breakpoint: 1024,
                  settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2,
                    infinite: true,
                  }
                },
                {
                  breakpoint: 800,
                  settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                  }
                },
                {
                  breakpoint: 400,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                }
              ]
        });
    //***************************
    // Partner Functions
    //***************************
      jQuery('.wm-partners-slider').slick({
          slidesToShow: 6,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 3000,
          infinite: true,
          prevArrow: "<span class='slick-arrow slick-arrow-left'><i class='wmicon-arrows4'></i></span>",
          nextArrow: "<span class='slick-arrow slick-arrow-right'><i class='wmicon-arrows4'></i></span>",
          responsive: [
                {
                  breakpoint: 1024,
                  settings: {
                    slidesToShow: 4,
                    slidesToScroll: 1,
                    infinite: true,
                  }
                },
                {
                  breakpoint: 800,
                  settings: {
                    slidesToShow: 3,
                    slidesToScroll: 1
                  }
                },
                {
                  breakpoint: 400,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                }
              ]
        });
    //***************************
    // BannerSlider Functions
    //***************************
      jQuery('.wm-banner-two').slick({
          slidesToShow: 1,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          infinite: true,
          arrows: false,
          fade: true,
          responsive: [
                {
                  breakpoint: 1024,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: true,
                  }
                },
                {
                  breakpoint: 800,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                },
                {
                  breakpoint: 400,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                }
              ]
        });
      jQuery('.wm-banner-four').slick({
          slidesToShow: 1,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          infinite: true,
          arrows: false,
          fade: true,
          responsive: [
                {
                  breakpoint: 1024,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: true,
                  }
                },
                {
                  breakpoint: 800,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                },
                {
                  breakpoint: 400,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                }
              ]
        });
    //***************************
    // ServiceSlider Functions
    //***************************
      jQuery('.wm-service-slider').slick({
          slidesToShow: 1,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          infinite: true,
          prevArrow: "<span class='slick-arrow slick-arrow-left'><i class='wmicon-arrows3'></i></span>",
          nextArrow: "<span class='slick-arrow slick-arrow-right'><i class='wmicon-arrows3'></i></span>",
          fade: true,
          responsive: [
                {
                  breakpoint: 1024,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: true,
                  }
                },
                {
                  breakpoint: 800,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                },
                {
                  breakpoint: 400,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                }
              ]
        });
    //***************************
    // UpcomingEvent Functions
    //***************************
      jQuery('.wm-upcoming-event-slider').slick({
          slidesToShow: 2,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          infinite: true,
          prevArrow: "<span class='slick-arrow slick-arrow-left'><i class='wmicon-arrows3'></i></span>",
          nextArrow: "<span class='slick-arrow slick-arrow-right'><i class='wmicon-arrows3'></i></span>",
          responsive: [
                {
                  breakpoint: 1024,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: true,
                  }
                },
                {
                  breakpoint: 800,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                },
                {
                  breakpoint: 400,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    arrows: false,
                  }
                }
              ]
        });
    //***************************
    // Testimonial Functions
    //***************************
      jQuery('.wm-thumb-testimonial').slick({
          slidesToShow: 1,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          infinite: true,
          prevArrow: "<span class='slick-arrow slick-arrow-left'><i class='wmicon-arrows3'></i></span>",
          nextArrow: "<span class='slick-arrow slick-arrow-right'><i class='wmicon-arrows3'></i></span>",
          responsive: [
                {
                  breakpoint: 1024,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: true,
                  }
                },
                {
                  breakpoint: 800,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                },
                {
                  breakpoint: 400,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                }
              ]
        });
    //***************************
    // RecentList Functions
    //***************************
      jQuery('.wm-recent-list-slider').slick({
          slidesToShow: 3,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          infinite: true,
          vertical: true,
          centerMode: true,
          prevArrow: "<span class='slick-arrow slick-arrow-left'><i class='wmicon-arrows2'></i></span>",
          nextArrow: "<span class='slick-arrow slick-arrow-right'><i class='wmicon-arrows2'></i></span>",
          responsive: [
                {
                  breakpoint: 1024,
                  settings: {
                    slidesToShow: 3,
                    slidesToScroll: 1,
                    infinite: true,
                  }
                },
                {
                  breakpoint: 800,
                  settings: {
                    slidesToShow: 3,
                    slidesToScroll: 1
                  }
                },
                {
                  breakpoint: 400,
                  settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1
                  }
                }
              ]
        });
    //***************************
    // Testimonial Functions
    //***************************
      jQuery('.wm-testimonial-navslider').slick({
          slidesToShow: 1,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          infinite: true,
          prevArrow: "<span class='slick-arrow slick-arrow-left'><i class='wmicon-arrows2'></i></span>",
          nextArrow: "<span class='slick-arrow slick-arrow-right'><i class='wmicon-arrows2'></i></span>",
          responsive: [
                {
                  breakpoint: 1024,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: true,
                  }
                },
                {
                  breakpoint: 800,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    arrows: false,
                  }
                },
                {
                  breakpoint: 400,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    arrows: false,
                  }
                }
              ]
        });
    //***************************
    // Partner Two Functions
    //***************************
      jQuery('.wm-partners-slider-two').slick({
          slidesToShow: 6,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          infinite: true,
          prevArrow: "<span class='slick-arrow slick-arrow-left'><i class='wmicon-arrows2'></i></span>",
          nextArrow: "<span class='slick-arrow slick-arrow-right'><i class='wmicon-arrows2'></i></span>",
          responsive: [
                {
                  breakpoint: 1024,
                  settings: {
                    slidesToShow: 4,
                    slidesToScroll: 1,
                    infinite: true,
                  }
                },
                {
                  breakpoint: 800,
                  settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1
                  }
                },
                {
                  breakpoint: 400,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                }
              ]
        });
      jQuery('.wm-partners-slider-classic').slick({
          slidesToShow: 6,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          infinite: true,
          prevArrow: "<span class='slick-arrow slick-arrow-left'><i class='wmicon-arrows'></i></span>",
          nextArrow: "<span class='slick-arrow slick-arrow-right'><i class='wmicon-arrows'></i></span>",
          responsive: [
                {
                  breakpoint: 1024,
                  settings: {
                    slidesToShow: 4,
                    slidesToScroll: 1,
                    infinite: true,
                  }
                },
                {
                  breakpoint: 800,
                  settings: {
                    slidesToShow: 4,
                    slidesToScroll: 1
                  }
                },
                {
                  breakpoint: 400,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                }
              ]
        });
    //***************************
    // Partner Two Functions
    //***************************
      jQuery('.wm-ourprofessors-slider').slick({
          slidesToShow: 3,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          infinite: true,
          prevArrow: "<span class='slick-arrow slick-arrow-left'><i class='wmicon-arrows'></i></span>",
          nextArrow: "<span class='slick-arrow slick-arrow-right'><i class='wmicon-arrows'></i></span>",
          responsive: [
                {
                  breakpoint: 1024,
                  settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                    infinite: true,
                  }
                },
                {
                  breakpoint: 800,
                  settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1
                  }
                },
                {
                  breakpoint: 400,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                }
              ]
        });
    //********************************
    // TestimonialModren Functions
    //********************************
      jQuery('.wm-modren-testimonial-slider').slick({
          slidesToShow: 2,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          infinite: true,
          prevArrow: "<span class='slick-arrow slick-arrow-left'><i class='wmicon-arrows'></i></span>",
          nextArrow: "<span class='slick-arrow slick-arrow-right'><i class='wmicon-arrows'></i></span>",
          responsive: [
                {
                  breakpoint: 1024,
                  settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                    infinite: true,
                  }
                },
                {
                  breakpoint: 800,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                },
                {
                  breakpoint: 400,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                }
              ]
        });

    //***************************
    // Click to Top Button
    //***************************
    jQuery('.backtop-btn').on("click", function() {
        jQuery('html, body').animate({
            scrollTop: 0
        }, 800);
        return false;
    });

    //***************************
    // Countdown Function
    //***************************
    jQuery(function() {
        var austDay = new Date();
        austDay = new Date(austDay.getFullYear() + 1, 1 - 1, 26);
        jQuery('#wm-countdown').countdown({
            until: austDay
        });
        jQuery('#year').text(austDay.getFullYear());
    });

    //***************************
    // WordCounter Function
    //***************************
    jQuery(".word-count").counterUp({
        delay: 10,
        time: 1000
    });
    //***************************
    // Inc-Dec Function
    //***************************
    jQuery(function(){
      jQuery("#wm-inc").click(function(){
        jQuery(":text[name='qty']").val( Number($(":text[name='qty']").val()) + 1 );
      });
      jQuery("#wm-dec").click(function(){
        jQuery(":text[name='qty']").val( Number($(":text[name='qty']").val()) - 1 );
      });
    });
    jQuery(function(){
      jQuery("#wm-incs").click(function(){
        jQuery(":text[name='qtys']").val( Number($(":text[name='qtys']").val()) + 1 );
      });
      jQuery("#wm-decs").click(function(){
        jQuery(":text[name='qtys']").val( Number($(":text[name='qtys']").val()) - 1 );
      });
    });
    jQuery(function(){
      jQuery("#wm-incd").click(function(){
        jQuery(":text[name='qtyd']").val( Number($(":text[name='qtyd']").val()) + 1 );
      });
      jQuery("#wm-decd").click(function(){
        jQuery(":text[name='qtyd']").val( Number($(":text[name='qtyd']").val()) - 1 );
      });
    });

    //***************************
    // PrettyPhoto Function
    //***************************
    jQuery("area[data-rel^='prettyPhoto']").prettyPhoto();

    jQuery(".gallery:first a[data-rel^='prettyPhoto']").prettyPhoto({
        animation_speed: 'normal',
        theme: 'facebook',
        social_tools: '',
        slideshow: 3000,
        autoplay_slideshow: false
    });
    jQuery(".gallery:gt(0) a[data-rel^='prettyPhoto']").prettyPhoto({
        animation_speed: 'fast',
        slideshow: 10000,
        hideflash: true
    });

    jQuery("#custom_content a[data-rel^='prettyPhoto']:first").prettyPhoto({
        custom_markup: '<div id="map_canvas" style="width:260px; height:265px"></div>',
        changepicturecallback: function() {
            initialize();
        }
    });

    jQuery("#custom_content a[data-rel^='prettyPhoto']:last").prettyPhoto({
        custom_markup: '<div id="bsap_1259344" class="bsarocks bsap_d49a0984d0f377271ccbf01a33f2b6d6"></div><div id="bsap_1237859" class="bsarocks bsap_d49a0984d0f377271ccbf01a33f2b6d6" style="height:260px"></div><div id="bsap_1251710" class="bsarocks bsap_d49a0984d0f377271ccbf01a33f2b6d6"></div>',
        changepicturecallback: function() {
            _bsap.exec();
        }
    });

    //***************************
    // Responsive Video Function
    //***************************
    jQuery(".wm-main-section").fitVids();

    //***************************
	// Skills Function
	//***************************
	jQuery('.skillbar').each(function() {
	    jQuery(this).appear(function() {
	        jQuery(this).find('.count-bar').animate({
	            width:jQuery(this).attr('data-percent')
	        },3000);
	        var percent = jQuery(this).attr('data-percent');
	        jQuery(this).find('.count').html('<span>' + percent + '</span>');
	    });
	});

	jQuery('[data-toggle="tooltip"]').tooltip();

	//***************************
	// CartToggle Function
	//***************************
	jQuery('a.wm-cartbtn').on("click", function(){
        jQuery('.wm-cart-box').slideToggle('slow');
        return false;
    });
    jQuery('html').on("click", function() { jQuery(".wm-cart-box").fadeOut(); });
	jQuery('.wm-navicons,.wm-cartsection').on("click", function(event){ event.stopPropagation(); });

    //***************************
    // LoginToggleClass Function
    //***************************
    jQuery('.wm-modallogin-form p a').on("click", function(){
        jQuery('.modal-body').toggleClass('wm-login-toggle');
        return false;
    });

	//********************************
    // Mediaelementplayer Function
    //********************************
    jQuery('video').mediaelementplayer({
		success: function(player, node) {
			jQuery('#' + node.id + '-mode').html('mode: ' + player.pluginType);
		}
	});

  //***************************
  // NiceScroll Function
  //***************************
    jQuery(".wm-history-list").niceScroll("",{
      cursorcolor:"#a6abc1",
      cursoropacitymax:1,
      boxzoom:true,
      autohidemode: false,
          background: '#5a617d',
          cursorborderradius: '20px 20px 0px 0px',
          cursorminheight: 60,
          cursorwidth: 8,
          cursorborder: 0,
          touchbehavior:true,
          railoffset:   {top: 0, left: -450, },
          railpadding:  { top: 0, right: 0, left: 0, bottom: 0, },
    });
    jQuery(".wm_widget_navlist ul").niceScroll("",{
      cursorcolor:"#3498db",
      cursoropacitymax:1,
      boxzoom:true,
      autohidemode: false,
          background: '#e3e3e3',
          cursorborderradius: '20px 20px 0px 0px',
          cursorminheight: 60,
          cursorwidth: 8,
          cursorborder: 0,
          touchbehavior:true,
          railoffset:   {top: 23, left: -332, right: 0, },
          railpadding:  { top: 0, right: 0, left: 0, bottom: 44, },
    });
    jQuery(".wm-history-list-color").niceScroll("",{
      cursorcolor:"#6b6b6b",
      cursoropacitymax:1,
      boxzoom:true,
      autohidemode: false,
          background: '#494949',
          cursorborderradius: '20px 20px 0px 0px',
          cursorminheight: 60,
          cursorwidth: 8,
          cursorborder: 0,
          touchbehavior:true,
          railoffset:   {top: 0, left: -450, },
          railpadding:  { top: 0, right: 0, left: 0, bottom: 0, },
    });
    jQuery(".widget_categories ul,.widget_scroll-box ul").niceScroll("",{
      cursorcolor:"#dbdbdb",
      cursoropacitymax:1,
      boxzoom:true,
      autohidemode: false,
          background: '#f5f5f5',
          cursorborderradius: '20px 20px 0px 0px',
          cursorminheight: 60,
          cursorwidth: 8,
          cursorborder: 0,
          touchbehavior:true,
          railoffset:   {top: 0, left: 0, },
          railpadding:  { top: 0, right: 0, left: 0, bottom: 0, },
    });
    jQuery(".wm-sidebar ul").niceScroll("",{
      cursorcolor:"#b99663",
      cursoropacitymax:1,
      boxzoom:true,
      autohidemode: false,
          background: '#e3e3e3',
          cursorborderradius: '20px 20px 0px 0px',
          cursorminheight: 60,
          cursorwidth: 8,
          cursorborder: 0,
          touchbehavior:true,
          railoffset:   {top: -10, left: -215, },
          railpadding:  { top: 0, right: 0, left: 0, bottom: 0, },
    });

});

//***************************
// News FilterAble Function
//***************************
jQuery(function($) {
    $('.wm-filterable li,.wm-filterable-link li').on("click", function(event) {
        event.preventDefault();
        var target = $(this).find('>a').prop('hash');
        $('html, body').animate({
            scrollTop: $(target).offset().top
        }, 500);
    });
    $("a.preview").prettyPhoto({
        social_tools: false
    });
    $(window).load(function() {
        $portfolio = $('.wm-gallery,.wm-our-professors,.wm-filter-event');
        $portfolio.isotope({
            itemSelector: 'li',
            layoutMode: 'fitRows',
        });
        $portfolio_selectors = $('.wm-filterable li a,.wm-filterable-link li a');
        $portfolio_selectors.on('click', function() {
            $portfolio_selectors.removeClass('active');
            $(this).addClass('active');
            var selector = $(this).attr('data-filter');
            $portfolio.isotope({
                filter: selector
            });
            return false;
        });
    });
});


//***************************
// GoogleMap Function
//***************************
google.maps.event.addDomListener(window, 'load', init);

function init() {
    // Basic options for a simple Google Map
    // For more options see: https://developers.google.com/maps/documentation/javascript/reference#MapOptions
    var mapOptions = {
        // How zoomed in you want the map to start at (always required)
        zoom: 11,

        // The latitude and longitude to center the map (always required)
        center: new google.maps.LatLng(40.6700, -73.9400), // New York

        // How you would like to style the map. 
        // This is where you would paste any style found on Snazzy Maps.
        styles: [{"featureType":"administrative","elementType":"labels","stylers":[{"visibility":"simplified"},{"color":"#4e5256"}]},{"featureType":"administrative","elementType":"labels.text.fill","stylers":[{"color":"#4e5256"},{"visibility":"simplified"}]},{"featureType":"landscape","elementType":"all","stylers":[{"color":"#ffffff"},{"visibility":"off"}]},{"featureType":"landscape","elementType":"geometry.fill","stylers":[{"visibility":"simplified"}]},{"featureType":"landscape","elementType":"geometry.stroke","stylers":[{"visibility":"simplified"}]},{"featureType":"landscape.man_made","elementType":"all","stylers":[{"visibility":"simplified"}]},{"featureType":"poi","elementType":"all","stylers":[{"visibility":"off"}]},{"featureType":"road","elementType":"all","stylers":[{"saturation":-100},{"lightness":45},{"visibility":"simplified"},{"hue":"#ff0000"}]},{"featureType":"road","elementType":"geometry.fill","stylers":[{"visibility":"simplified"},{"color":"#007ec8"},{"saturation":"-29"},{"lightness":"56"}]},{"featureType":"road.highway","elementType":"all","stylers":[{"visibility":"simplified"},{"saturation":"82"},{"lightness":"-6"},{"gamma":"1"},{"hue":"#006dff"}]},{"featureType":"road.highway","elementType":"geometry","stylers":[{"color":"#007ec8"},{"lightness":"56"},{"saturation":"-29"}]},{"featureType":"road.highway","elementType":"labels","stylers":[{"visibility":"off"}]},{"featureType":"road.highway","elementType":"labels.text","stylers":[{"visibility":"off"}]},{"featureType":"road.arterial","elementType":"labels.icon","stylers":[{"visibility":"simplified"}]},{"featureType":"road.local","elementType":"all","stylers":[{"visibility":"simplified"}]},{"featureType":"transit","elementType":"all","stylers":[{"visibility":"off"}]},{"featureType":"water","elementType":"all","stylers":[{"color":"#e5e8ed"},{"visibility":"on"}]}]
    };

    // Get the HTML DOM element that will contain your map 
    // We are using a div with id="map" seen below in the <body>
    var mapElement = document.getElementById('map');

    // Create the Google Map using our element and options defined above
    var map = new google.maps.Map(mapElement, mapOptions);

    // Let's also add a marker while we're at it
    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(40.6700, -73.9400),
        map: map,
        title: 'Snazzy!'
    });
}