// JavaScript Document
$(document).ready(function(e) {
		var Heightyy=document.documentElement.clientHeight;
		$(".total").height(Heightyy*0.95);
		
		//主菜单点击事件
		  mainMmenu();
		
		//子菜单点击事件
		  submenuWay();
		  
		//主菜单的hover事件
		$(".mainmenu").hover(function() {
			 /*alert($(this).children().eq(0).text());*/
			 var zj=$(this).hasClass("activebd") ;
			 //判断是否点中，点中就不加hover事件
			if(zj==true){
				 $(this).children().eq(0).removeClass("hover_active");
			}else{ 
				 $(this).children().eq(0).addClass("hover_active");
			}
			}, function() {
				 $(this).children().eq(0).removeClass("hover_active");
		});
					
	});
 //主菜单点击事件
 function mainMmenu(){
		 var ruleId=$(".mainmenu");
		 var index;
		 for( var i=0; i<ruleId.length; i++){
				ruleId[i].index=i;
				$(ruleId[i]).click( function(){
						for( var i=0; i<ruleId.length; i++){
							$(ruleId[i]).children().eq(1).attr("src","images/no_img0"+i+".png");
							$(ruleId[i]).children().eq(2).css('color','#297fb8');
							$(ruleId[i]).removeClass("activebd");
							$(ruleId[i]).children().eq(3).attr("src","images/no_arrear.png");
							$(ruleId[i]).next().hide();
						}
							$(this).children().eq(1).attr("src","images/img0"+(this.index)+".png");
							//替换背景颜色
							$(this).addClass("activebd");
							//替换字体颜色
							$(this).children().eq(2).css('color','#fff');
							//替换箭头
							$(this).children().eq(3).attr("src","images/arrear.png");
							//子菜单显示事件
							$(this).next().show();
					});
			 }	
		}
		
//子菜单点击事件
 function submenuWay(){
		 var submenu=$(".submenu li");
		 var index;
		 for( var i=0; i<submenu.length; i++){
				submenu[i].index=i;
				$(submenu[i]).click( function(){
						for( var i=0; i<submenu.length; i++){
							$(submenu[i]).removeClass("act_sub");
						}
							$(this).addClass("act_sub");
					});
			 }	
		}
		
		