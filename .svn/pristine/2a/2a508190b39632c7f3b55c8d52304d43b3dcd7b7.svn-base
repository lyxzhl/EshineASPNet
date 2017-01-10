// JScript 文件
var xmlHttp;
    function createXMLHttpRequest()
    {
        xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");
    }
    function ExeRequest()
    {
        createXMLHttpRequest();
        var url="../ashx/addProducts.ashx";
//        ?pName="+document.getElementById("TextBox1").value+"&pCID=1&pUnit="+document.getElementById("TextBox2").value
        xmlHttp.open("GET",url,true);
        xmlHttp.onreadystatechange=showRequest;
        xmlHttp.send();
    }
    function showRequest()
    {
        if(xmlHttp.readyState==4)
        {
            if(xmlHttp.status==200)
            {
                alert(xmlHttp.responseText);
            }
        }
    }
    function ClearTxt() 
    { 
        var txts=document.getElementsByTagName("input"); 
        for(var i=0;i <txts.length;i++) 
        { 
            if(txts[i].type=="text") 
            { 
                txts[i].value =""; 
            } 
        } 
    }
    function ClearSelect()
    {
        var txts=document.getElementsByTagName("select"); 
        for(var i=0;i <txts.length;i++) 
        { 
            txts[i].selectedIndex=0;
        }
    }
    function ClearAll()
    {
        ClearTxt();
        ClearSelect();
    }
