// JScript 文件

//这里的JavaScript的作用是用于后台参数组合的添加的验证
//管理者在后台添加新才参数组合的时候判断用户选择的参数组合是否复合要求
function Check()
{
    //用户类型的选择判断checked
    var objPlys0=document.getElementById("ctl00_ContentPlaceHolder1_rdlPlyType_0");
    var objPlys1=document.getElementById("ctl00_ContentPlaceHolder1_rdlPlyType_1");
    if (!objPlys0.checked && !objPlys1.checked)
    {
        alert("请选择用户的类型！");
        return false;
    }
    
    //用户房型的选择判断
    var objhouses=document.getElementById("ctl00_ContentPlaceHolder1_drpHouseType");
    var selectedHouseId=objhouses.selectedIndex;
    if(selectedHouseId==0)
    {
        alert("请选择房型！");
        return false;
    }
    
    //获取卫生间的数量
    var toilNum=1; 
    if (selectedHouseId==1 || selectedHouseId==2)
    {
        toilNum=1;
    }else if(selectedHouseId==3 || selectedHouseId==4)
    {
        toilNum=2
    }else if(selectedHouseId==5)
    {
        toilNum=3;
    }else if(selectedHouseId==6)
    {
        toilNum=4;
    }
    
    //家庭的人口数
    var objold=document.getElementById("ctl00_ContentPlaceHolder1_drpOldMan");
    var objyouth=document.getElementById("ctl00_ContentPlaceHolder1_drpYouthMan");
    var objchild=document.getElementById("ctl00_ContentPlaceHolder1_drpChild");
    
    var oldnum=objold.options[objold.selectedIndex].value;
    var youthnum=objyouth.options[objyouth.selectedIndex].value;
    var childnum=objchild.options[objchild.selectedIndex].value;
    
    if(oldnum==0&&youthnum==0&&childnum==0)
    {
        alert("请选择家庭人员的组成!");
        return false;
    }
        
    //洗浴工具
    var objlinyu=document.getElementById("ctl00_ContentPlaceHolder1_drpLinYu");
    var objlinyufang=document.getElementById("ctl00_ContentPlaceHolder1_drpLinYuFang");
    var objyugang=document.getElementById("ctl00_ContentPlaceHolder1_drpYuGang");
    var objchonglang=document.getElementById("ctl00_ContentPlaceHolder1_drpChongLang");
    
    //索引和值是相等的，因此，我们可以讲索引当成值的使用
    var linyunum=objlinyu.selectedIndex;
    var linyufangnum=objlinyufang.selectedIndex;
    var yugangnum=objyugang.selectedIndex;
    var chonglangnum=objchonglang.selectedIndex;
    
    if(linyunum==0&&linyufangnum==0&&yugangnum==0&&chonglangnum==0)
    {
        alert("请选择洗浴工具！");
        return false;
    }
    
    /*var xiyu=linyunum+linyufangnum+yugangnum+chonglangnum;
    if(xiyu != toilNum)
    {
        alert("你选择的洗浴用具的数目应该和浴室的数目一致！");
        return false;
    }*/
}

//-----------------------------------------------------
//    选中当前模块下的所有页面 checkbox
//    第一个参数是表单对象，第二个是checkbox的Id，第三个是checkbox的value（类别的ID），第四个是checkbox本身
//-----------------------------------------------------
function sel_products(formobj, ckid, ckval, ckele)
{
    var obj = eval(formobj.name.toString() + ".ck_product" + ckval.toString());
    
    for (var i=0; i<formobj.elements.length; i++)
    {
        var ele = formobj.elements[i];
        
        if (ele.name == ("ck_product" + ckval.toString()))
            ele.checked = ckele.checked;
    }
}

//-----------------------------------------------------
//    如果选中某页面的 checkbox ，则要回选其所归属的模块
//-----------------------------------------------------
function sel_category(formobj, ckele,cktext, cktextval)
{
    var categoryval = ckele.name.toString().substring(10); 
    
    // 如果当前的商品 checkbox 为选中状态，则判断类型是否为选中，若不是则选中        
    if (ckele.checked)
    {     
        for (var i=0; i<formobj.elements.length; i++)
        {
            var ele = formobj.elements[i];              

            if (ele.value == categoryval)
            {
                if (ele.name.toString().indexOf("ck_category") != -1)
                {
                    ele.checked = true; 

                }
                                   
            }
        }
    }
    else
    {
        var hasck = false;
        for (var i =0; i<formobj.elements.length; i++)
        {
            var ele = formobj.elements[i];
            
            if (ele.name.toString() == ckele.name.toString())
            {
                if (ele.checked)
                {
                    hasck = true;
                    break;
                }
            }
        }
        
        if (!hasck)
        {
            for (var i=0; i<formobj.elements.length; i++)
            {
                var ele = formobj.elements[i];                

                if (ele.value == categoryval)
                {
                    if (ele.name.toString().indexOf("ck_category") != -1)
                        ele.checked = false;
                }
            }            
        }
            
    }
}


//-----------------------------------------------------
//    根据 parm 值反选页面中的 Module 对象
//-----------------------------------------------------
function pageItemChecked(parmval, formobj)
{        
    for (var i=0; i<formobj.elements.length; i++)
    {
        var ele = formobj.elements[i];
        
        if (ele.name == ("ck_product" + parmval.toString()) && ele.checked)
            return true;
    }

    return false;
}