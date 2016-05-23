// JavaScript Document
 $(document).ready(function(e) {
 	
 	 var Heightyy=$(window).height();
	 var Widthyy=$(window).width();
	 $(".swiper-wrapper").height(Heightyy).width(Widthyy);
	 $(".swiper-slide").height(Heightyy).width(Widthyy);
	 /*预加载  start*/
	 var aImg=document.getElementsByTagName("img");
	 var aSrc=[];
	 for(var i=0;i<aImg.length;i++){
		 aSrc.push(aImg[i].src);
		 };
	 
	 //alert(aSrc.length);
	preloadimages(aSrc).done(function(images){
							  /* alert(images.length) //alerts 3
							   alert(images[0].src+" "+images[0].width) //alerts '1.gif 220'*/
							   //当图片全部加载完成之后，执行此处的代码
							  
							 //images参数是Array类型，对应加载进来的图像
								 //images[0] 对应的是第一张图像
							})
	
	function preloadimages(arr){
			var newimages=[];
			var loadedimages=0;
			var postaction=function(){}  //此处增加了一个postaction函数
			var arr=(typeof arr!="object")? [arr] : arr
			
			function imageloadpost(){
				loadedimages++;
				if (loadedimages==arr.length){
					postaction(newimages); //加载完成用我们调用postaction函数并将newimages数组做为参数传递进去					
					setTimeout(function(){$("div.loading-container").fadeOut(1000);},1000)
					setTimeout(function(){
						$("div.main-container").fadeIn(1000);
  					},2000);
				}
			}
			for (var i=0; i<arr.length; i++){
				newimages[i]=new Image()
				newimages[i].src=arr[i]
				newimages[i].onload=function(){
					imageloadpost()
				}
				newimages[i].onerror=function(){
					imageloadpost()
				}
			}
			return { //此处返回一个空白对象的done方法
				done:function(f){
					postaction=f || postaction
				}
			}
			}

                  			
 });
	 /*预加载   end*/
	 
	 
