/*
 * jquery.ui.potato.menu
 * 
 * Copyright (c) 2009 makoto_kw (makoto.kw@gmail.com)
 * Dual licensed under the new BSD licenses.
 * 
 * Version: 1.0
 */
(function($) {
	$.fn.extend({
		ptMenu:function(arg) {
/*
			var defaltOption = {
				vertical:false,
				menuItemSelector: 'li',
				menuGroupSelector: 'ul',
				firstClass:'potato-menu',
				menuItemClass:'potato-menu-item',
				menuGroupClass:'potato-menu-group',
				verticalClass:'potato-menu-vertical',
				holizontalClass:'potato-menu-holizontal',
				hasVerticalClass:'potato-menu-has-vertical',
				hasHolizontalClass:'potato-menu-has-holizontal',
				showDuration: 350,
				hideDuration: 100
			}*/
			
			////////////////////test////////////////////////
			var Sys = {};
            var ua = navigator.userAgent.toLowerCase();
            var s;
            (s = ua.match(/msie ([\d.]+)/)) ? Sys.ie = s[1] : 0;

            //以下进行测试
            var defaltOption;
             defaltOption = {
				vertical:false,
				menuItemSelector: 'li',
				menuGroupSelector: 'ul',
				firstClass:'potato-menu',
				menuItemClass:'potato-menu-item',
				menuGroupClass:'potato-menu-group',
				verticalClass:'potato-menu-vertical',
				holizontalClass:'potato-menu-holizontal',
				hasVerticalClass:'potato-menu-has-vertical',
				hasHolizontalClass:'potato-menu-has-holizontal',
				showDuration: 350,
				hideDuration: 100 }
            if (document.all ) {
            if (Number(Sys.ie)<=6)
            {
                defaltOption = {
				vertical:false,
				menuItemSelector: 'li',
				menuGroupSelector: 'ul',
				firstClass:'potato-menu-ie6',
				menuItemClass:'potato-menu-item-ie6',
				menuGroupClass:'potato-menu-group-ie6',
				verticalClass:'potato-menu-vertical-ie6',
				holizontalClass:'potato-menu-holizontal-ie6',
				hasVerticalClass:'potato-menu-has-vertical-ie6',
				hasHolizontalClass:'potato-menu-has-holizontal-ie6',
				showDuration: 350,
				hideDuration: 100 }
            }
            else
            {
                defaltOption = {
				vertical:false,
				menuItemSelector: 'li',
				menuGroupSelector: 'ul',
				firstClass:'potato-menu',
				menuItemClass:'potato-menu-item',
				menuGroupClass:'potato-menu-group',
				verticalClass:'potato-menu-vertical',
				holizontalClass:'potato-menu-holizontal',
				hasVerticalClass:'potato-menu-has-vertical',
				hasHolizontalClass:'potato-menu-has-holizontal',
				showDuration: 350,
				hideDuration: 100 }
            }
            }

			/////////////////////testend///////////////////////

			
			var option = (typeof(arg)!='string') ? $.extend(defaltOption,arg) : $.extend(defaltOption,{});
			var $menu = $(this).addClass(option.firstClass).addClass((option.vertical) ? option.verticalClass : option.holizontalClass);
			var $menuItems = $menu.find(option.menuItemSelector).addClass(option.menuItemClass);
			var $menuGroups = $menu.find(option.menuGroupSelector).addClass(option.menuGroupClass);
			$menuGroups.parent().each(function(index){
				var bottom = $(this).parent(option.menuGroupSelector+'.'+option.firstClass).length == 1 && !option.vertical;
				var $menuGroup = $(this).addClass((bottom) ? option.hasVerticalClass : option.hasHolizontalClass)
					.children(option.menuGroupSelector+':first').addClass(option.verticalClass)
				$(this)
					.hover(
						function(e) {
							var offset = (bottom) ? {left:'0',top:''} : {left:$(this).width()+'px',top:'0'};
							$menuGroup.css({left:offset.left,top:offset.top}).fadeIn(option.showDuration);
						},
						function(e) {
							$menuGroup.fadeOut(option.hideDuration);
						}
					)
				;
			});
			$menu.find('a[href^="#"]').click(function() {
				$menuGroups.fadeOut(option.hideDuration);
				return ($(this).attr('href')=='#') ? false : true;
			})
			;
			return this;
		}
	})
})(jQuery);