//javascript file

$(document).ready(function()
{
	slide("#sliding-navigation", 25, 15, 150, .8);
});

function slide(navigation_id, pad_out, pad_in, time, multiplier)
{
	// 创建目标路径
	var list_elements = navigation_id + " li.sliding-element";
	var link_elements = list_elements + " a";
	
	// 计时器 ： 用于滑动动画 
//	var timer = 0;
	
	// 创建动画
/*	$(list_elements).each(function(i)
	{
		// margin left = - ([width of element] + [total vertical padding of element])
		$(this).css("margin-left","-180px");
		// 更新时间
		timer = (timer*multiplier + time);
		$(this).animate({ marginLeft: "0" }, timer);
		$(this).animate({ marginLeft: "15px" }, timer);
		$(this).animate({ marginLeft: "0" }, timer);
	});*/

	// 创建动画悬停效果	
	$(link_elements).each(function(i)
	{
		$(this).hover(
		function()
		{
			$(this).animate({ paddingLeft: pad_out }, 150);
		},		
		function()
		{
			$(this).animate({ paddingLeft: pad_in }, 150);
		});
	});
}