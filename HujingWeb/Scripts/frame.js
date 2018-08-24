//杈撳叆浣犲笇鏈涙牴鎹〉闈㈤珮搴﹁嚜鍔ㄨ皟鏁撮珮搴︾殑iframe鐨勫悕绉扮殑鍒楄〃 
//鐢ㄩ€楀彿鎶婃瘡涓猧frame鐨処D鍒嗛殧. 渚嬪: ["myframe1", "myframe2"]锛屽彲浠ュ彧鏈変竴涓獥浣擄紝鍒欎笉鐢ㄩ€楀彿銆  
//瀹氫箟iframe鐨処D
var iframeids = ["myiframe"];
//濡傛灉鐢ㄦ埛鐨勬祻瑙堝櫒涓嶆敮鎸乮frame鏄惁灏唅frame闅愯棌 yes 琛ㄧず闅愯棌锛宯o琛ㄧず涓嶉殣钘  
var iframehide = "yes";
function dyniframesize() {
    var dyniframe = new Array();
    for (var i = 0; i < iframeids.length; i++) {
        if (document.getElementById) {
            //鑷姩璋冩暣iframe楂樺害 
            dyniframe[dyniframe.length] = document.getElementById(iframeids[i]);
            if (dyniframe[i] && !window.opera) {
                dyniframe[i].style.display = "block";
                if (dyniframe[i].contentDocument && dyniframe[i].contentDocument.body.offsetHeight) {
                    //濡傛灉鐢ㄦ埛鐨勬祻瑙堝櫒鏄疘E 
                    var contentDocHeight = dyniframe[i].contentDocument.body.offsetHeight;
                    dyniframe[i].height = contentDocHeight + 100;
                }
                else if (dyniframe[i].Document && dyniframe[i].Document.body.scrollHeight) {
                    //鍏跺畠娴忚鍣 
                    dyniframe[i].height = dyniframe[i].Document.body.scrollHeight + 100;
                }
            }
        }
        //鏍规嵁璁惧畾鐨勫弬鏁版潵澶勭悊涓嶆敮鎸乮frame鐨勬祻瑙堝櫒鐨勬樉绀洪棶棰  
        if ((document.all || document.getElementById) && iframehide == "no") {
            var tempobj = document.all ? document.all[iframeids[i]] : document.getElementById(iframeids[i]);
            tempobj.style.display = "block";
        }
    }
}
if (window.addEventListener) {
    window.addEventListener("load", dyniframesize, false);
}
else if (window.attachEvent) {
    window.attachEvent("onload", dyniframesize);
}
else {
    window.onload = dyniframesize;
}
