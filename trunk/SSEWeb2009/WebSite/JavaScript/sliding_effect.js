//javascript file

$(document).ready(function()
{
	slide("#sliding-navigation", 25, 15, 150, .8);
});

function slide(navigation_id, pad_out, pad_in, time, multiplier)
{
	// ����Ŀ��·��
	var list_elements = navigation_id + " li.sliding-element";
	var link_elements = list_elements + " a";
	
	// ��ʱ�� �� ���ڻ������� 
//	var timer = 0;
	
	// ��������
/*	$(list_elements).each(function(i)
	{
		// margin left = - ([width of element] + [total vertical padding of element])
		$(this).css("margin-left","-180px");
		// ����ʱ��
		timer = (timer*multiplier + time);
		$(this).animate({ marginLeft: "0" }, timer);
		$(this).animate({ marginLeft: "15px" }, timer);
		$(this).animate({ marginLeft: "0" }, timer);
	});*/

	// ����������ͣЧ��	
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