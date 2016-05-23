
var FC = FC || {};
FC.Index = FC.Index || {

	init: function() {
		$('.wrapper').hide();
		window.onload = function() {
			$("#popFail").remove();
			$('.wrapper').show();
		}
	},

	switchIndex: function(obj) {
		var box = obj.parentNode;
		if (box.className.indexOf("box_up") != -1) {
			box.className = "box";
			obj.innerHTML = '<span>收起</span>';
		} else {
			box.className = "box box_up";
			obj.innerHTML = '<span>更多</span>';
		}
	},

	// toggleList: function(obj) {
	// 	var box = obj.nextSibling;

	// }
}

var Index = FC.Index;
$(document).ready(Index.init);

$(function() {

	$("#tabs ul").idTabs("news");

	$(".showHouse").click(function(event) {
		var box = $(this).next();
		if(box.css("display") == 'none') {
			box.css({
				display: 'block'
			});
			box.parent().addClass('current').siblings().removeClass('current').children('.house_photo').hide();
		} else {
			box.css({
				display: 'none'
			});

			box.parent().removeClass('current');
		}

	});
	
});

