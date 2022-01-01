$(document).ready(function(){
	var stt = 0;
	startImg = parseInt($(".imager img:first").attr("stt"));
	endImg = parseInt($(".imager img:last").attr("stt"));
	ly = ++endImg;
	// alert(ly);
	
	// alert(startImg);
	
		$(".imager img").each(function(){
			if($(this).is(':visible')) {
				stt = parseInt($(this).attr("stt"));   
			}
		})
		// alert(stt)
	$("#next").click(function(){
		next = ++stt;
		if(next == endImg-1){
			stt = -1;
		}
		// alert(next);
		$(" .imager img").hide();
		$(".imager img").eq(next).show();
		
		
		$(".nut li").removeClass('active2');
		$(".nut li").addClass('molist');
		$(".nut li").eq(next).addClass('active2');
	});
	
	$("#prev").click(function(){
		
		// alert(startImg);
		if(stt == startImg){
			stt = ly;
		}
		prev = --stt;
		
		$(".imager img").hide();
		$(".imager img").eq(prev).show();
		$(".nut li").removeClass('active2');
		$(".nut li").addClass('molist');
		$(".nut li").eq(next).addClass('active2');
	});
	
	setInterval(function() {
		$("#next").click();
	},1423);
	
 });