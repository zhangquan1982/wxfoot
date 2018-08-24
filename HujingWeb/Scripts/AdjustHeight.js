/*
 * jQuery adjust height v1.0.0
 * Copyright 2015 jQuery adjust height v1.0.0
 * Released under the MIT license
 * Author：zhuzhangyi
 * Date: 2015-5-23 13:13:36
 * Demo:<iframe id="menuFrame" name="menuFrame" scrolling="no" src="1.html" frameborder="0"
 *      width="100%"></iframe>
 */
var AdjustHeight = function () {
    //调整父级页面Iframe高度
    this.SetSupIframe = function (iframeId) {
        var bodyHeight = $(document.body).height();
        var iframeCt = $(window.parent.document).find("#" + iframeId + "");
        iframeCt.height(bodyHeight + 95);
    },
        this.SupIframeAjust = function (iframeId) {
            $("#" + iframeId + "").load(function () {
                var mainHeight = $(this).contents().find("body").height() + 85;
                $(this).height(mainHeight);
            });
        }
};