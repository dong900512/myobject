// JScript 文件
 
    //<![CDATA[
    var previewBox = document.getElementById('PreviewBox');
    var previewImage = document.getElementById('PreviewImage');
    var previewUrl = document.getElementById('previewUrl');
    var previewFrom = null;
    var previewTimeoutId = null;
    var loadingImg = '/manage/img/loading.gif';
    var maxWidth = 250;
    var maxHeight = 250;

    /****************************************/
    /* 获取页面元素的坐标
    /****************************************/
    function getPosXY(a, offset) 
    {
        var p=offset?offset.slice(0):[0,0],tn;
        while(a) 
        {
             tn=a.tagName.toUpperCase();
             if (tn == 'IMG') 
             {
                 a = a.offsetParent;
                 continue;
             }
             p[0]+=a.offsetLeft-(tn=="DIV"&&a.scrollLeft?a.scrollLeft:0);
             p[1]+=a.offsetTop-(tn=="DIV"&&a.scrollTop?a.scrollTop:0);
             if (tn=="BODY") break;
             a=a.offsetParent;
        }
        return p;
    }
    function checkComplete() 
    {
        if (checkComplete.__img && checkComplete.__img.complete)
        checkComplete.__onload();
    }
    
    checkComplete.__onload = function()
    {
        clearInterval(checkComplete.__timeId);
        var w = checkComplete.__img.width;
        var h = checkComplete.__img.height;
        if (w >= h && w > maxWidth) 
        {
            previewImage.style.width = maxWidth + 'px';
        } 
        else if (h >= w && h > maxHeight) 
        {
            previewImage.style.height = maxHeight + 'px';
        }
        else 
        {
            previewImage.style.width = previewImage.style.height = '';
        }
        previewImage.src = checkComplete.__img.src;
        previewUrl.href = checkComplete.href;
        checkComplete.__img = null;
        //previewImage.style.display = '';
    }
    
    /****************************************/
    /*  设置激发预览时间
    /****************************************/
    function showPreview(e) 
    {
        hidePreview();
        previewFrom = e.target || e.srcElement;
        previewImage.src = loadingImg;
        previewImage.style.width = previewImage.style.height = '';
        previewTimeoutId = setTimeout('_showPreview()', 0);
        checkComplete.__img = null;
    }

     /****************************************/
     /* 取消预览
     /****************************************/
    function hidePreview(e)
    {
        if (e)
        {
             var toElement = e.relatedTarget || e.toElement;
             //alert(toElement.innerHTML);
             while (toElement) 
             {
                  if (toElement.id == 'PreviewBox')
                   return;
                  toElement = toElement.parentNode;
             }
        }
        try
        {
            clearInterval(checkComplete.__timeId);
            checkComplete.__img = null;
            previewImage.src = null;
        }
        catch (e)
        {
        }
        clearTimeout(previewTimeoutId);
        previewBox.style.display = 'none';
    }
    
    /****************************************/
    /*    预览操作
    /****************************************/
    function _showPreview() 
    {
        //previewImage.style.display = 'none';
        checkComplete.__img = new Image();
        if (previewFrom.tagName.toUpperCase() == 'A')
         previewFrom = previewFrom.getElementsByTagName('img')[0];
        //获取大图的URL
        var largeSrc = previewFrom.getAttribute("large-src");
        var picLink = previewFrom.getAttribute("pic-link");
        if (!largeSrc) 
        return;
        else 
        {
             checkComplete.__img.src = largeSrc;
             checkComplete.href = picLink;
             checkComplete.__timeId = setInterval("checkComplete()", 20);
             var pos = getPosXY(previewFrom, [60, -2]);  //设置预览图显示的左右位置
             previewBox.style.left = pos[0] + 'px';
             previewBox.style.top = pos[1] + 'px';
             previewBox.style.display = 'block';
        }
    }
    //]]> 