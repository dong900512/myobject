//-----------------------------------------------------
//
//-----------------------------------------------------
function textarea_resize(textareaname,textareamp)
{
  var tt_num=5;
  if (textareamp=='-') { tt_num=-5; }
  var tt_obj=document.getElementById(textareaname);
  if (parseInt(tt_obj.rows)+tt_num>=3) { tt_obj.rows = parseInt(tt_obj.rows) + tt_num; }
  if (tt_num>0) { tt_obj.width="90%"; }
}

//-----------------------------------------------------
//
//-----------------------------------------------------
function del_nsort(t2,t3)
{
  if (t3=="yes")
  {
    var cf=window.confirm("您确定要删除主分类（"+t2+"）吗？\n其下的二级分类也将一并删除！\n\n删除后将不可恢复！是否确定该操作？");
    if (cf)
    { return true; }
    else
    { return false; }
  }
  else
  {
    var cf1=window.confirm("您确定要删除二级分类（"+t2+"）吗？\n\n删除后将不可恢复！是否确定该操作？");
    if (cf1)
    { return true; }
    else
    { return false; }
  }
  return false;
}

//-----------------------------------------------------
//    选中当前模块下的所有页面 checkbox
//    第一个参数是表单对象，第二个是checkbox的Id，第三个是checkbox的value（类别的ID），第四个是checkbox本身
//-----------------------------------------------------
function sel_pagebox(formobj, ckid, ckval, ckele)
{   
    for (var i=0; i<formobj.elements.length; i++)
    {
        var ele = formobj.elements[i];
        
        if (ele.name == ("ck_page" + ckval.toString()))
            ele.checked = ckele.checked;
    }
}

//-----------------------------------------------------
//    如果选中某页面的 checkbox ，则要回选其所归属的模块
//-----------------------------------------------------
function sel_modulebox(formobj, ckele,cktext, cktextval)
{
//    //geng 
//    for (var i=0; i<formobj.elements.length; i++)
//    {
//        var ele = formobj.elements[i];
//               
//        if (ele.name == ("ck_text" + ckval.toString()))
//        {
//            ele.style.display="none";
//                alert("111111");        
//        }

//    }


    var moduleval = ckele.name.toString().substring(7); 
    
    // 如果 当前的页面 checkbox 为选中状态，则判断模块是否为选中，若不是则选中        
    if (ckele.checked)
    { 
//    var aaa = cktext + cktextval.toString();
//    getElementByID(aaa).style.display="none";
    
        for (var i=0; i<formobj.elements.length; i++)
        {
            var ele = formobj.elements[i];              

            if (ele.value == moduleval)
            {
                if (ele.name.toString().indexOf("ck_module") != -1)
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

                if (ele.value == moduleval)
                {
                    if (ele.name.toString().indexOf("ck_module") != -1)
                        ele.checked = false;              
                }
            }            
        }
            
    }
}


//-----------------------------------------------------
//    根据 parm 值反选页面中的 Module 对象
//-----------------------------------------------------
function pageItemChecked(parm, formobj)
{        
    for (var i=0; i<formobj.elements.length; i++)
    {
        var ele = formobj.elements[i];
        
        if (ele.name == ("ck_page" + parm.toString()) && ele.checked)
            return true;
    }

    return false;
}
