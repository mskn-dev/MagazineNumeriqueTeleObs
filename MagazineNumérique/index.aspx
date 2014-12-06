<%@ Page Title="Accueil" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
    <!-- Home Section -->
    <section id="home" class="section parallax" data-stellar-background-ratio="0.4">
        <div id="revslider-container">
            <div id="revslider">
                <ul>
                    <li data-transition="random" data-slotamount="8" data-masterspeed="400" data-thumb="Ressources/img/Caroussel/imgCaroussel1.jpg" data-saveperformance="on"  data-title="Bollywood">
                        <img src="Ressources/img/revslider/dummy.png"  alt="slidebg1" data-lazyload="Ressources/img/Caroussel/imgCaroussel1.jpg" data-kenburns="on" data-bgposition="center center" data-duration="4800" data-bgfit="115" data-bgfitend="100" data-bgpositionend="center top" data-bgrepeat="no-repeat">
                        <div class="tp-caption rev-title rev-border sft stt" data-x="center" data-hoffset="25" data-y="215" data-start="1000" data-speed="2000"><span class="blue-colorr">Bollywood</span></div>

                        <div class="tp-caption rev-title rev-title-medium customin customout" data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;" data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;" data-start="600" data-splitin="chars" data-splitout="chars" data-elementdelay="0.3" data-endelementdelay="0.1" data-endspeed="600" data-x="center" data-y="300" data-speed="1200">condamnée à 26 ans de prison pour blasphème</div>
                    </li>
                    <li data-transition="random" data-slotamount="8" data-masterspeed="450" data-thumb="Ressources/img/Caroussel/imgCaroussel2.jpg" data-saveperformance="on"  data-title="Emmanuelle Devos">
                        <img src="Ressources/img/revslider/dummy.png"  alt="slidebg2" data-lazyload="Ressources/img/Caroussel/imgCaroussel2.jpg"  data-kenburns="on" data-bgposition="center bottom" data-duration="4200" data-bgfit="115" data-bgfitend="100" data-bgpositionend="center center" data-bgrepeat="no-repeat">
                                
                        <div class="tp-caption rev-title rev-border sft stt" data-x="center" data-y="210" data-start="1000" data-speed="2000">Emmanuelle Devos</div>

                        <div class="tp-caption rev-title rev-title-medium customin customout" data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;" data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;" data-start="600" data-splitin="chars" data-splitout="chars" data-elementdelay="0.3" data-endelementdelay="0.1" data-endspeed="600" data-x="center" data-y="300" data-speed="1200">Simone Veil par Emmanuelle Devos</div>
                    </li>
                    <li data-transition="random" data-slotamount="8" data-masterspeed="450" data-thumb="Ressources/img/Caroussel/imgCaroussel3.jpg" data-saveperformance="on"  data-title="Cantona">
                        <img src="Ressources/img/revslider/dummy.png"  alt="slidebg2" data-lazyload="Ressources/img/Caroussel/imgCaroussel3.jpg"  data-kenburns="on" data-bgposition="center bottom" data-duration="4200" data-bgfit="115" data-bgfitend="100" data-bgpositionend="center center" data-bgrepeat="no-repeat">
                                
                        <div class="tp-caption rev-title rev-border sft stt" data-x="center" data-y="210" data-start="1000" data-speed="2000">Cantona</div>

                        <div class="tp-caption rev-title rev-title-medium customin customout" data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;" data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;" data-start="600" data-splitin="chars" data-splitout="chars" data-elementdelay="0.3" data-endelementdelay="0.1" data-endspeed="600" data-x="center" data-y="300" data-speed="1200">"Il faut rappeler la vérité sur l'immigration"</div>
                    </li>
                </ul>
            </div><!-- End revslider -->
        </div><!-- End revslider-container -->
    </section><!-- End #home -->
 
    <script>
        $(function () {
            // Slider Revolution for Home Section
            jQuery('#revslider').revolution({
                delay: 9000,
                startwidth: 1140,
                startheight: 600,
                onHoverStop: "true",
                hideThumbs: 0,
                lazyLoad: "on",
                navigationType: "none",
                navigationHAlign: "center",
                navigationVAlign: "bottom",
                navigationHOffset: 0,
                navigationVOffset: 20,
                soloArrowLeftHalign: "left",
                soloArrowLeftValign: "center",
                soloArrowLeftHOffset: 0,
                soloArrowLeftVOffset: 0,
                soloArrowRightHalign: "right",
                soloArrowRightValign: "center",
                soloArrowRightHOffset: 0,
                soloArrowRightVOffset: 0,
                touchenabled: "on",
                stopAtSlide: -1,
                stopAfterLoops: -1,
                dottedOverlay: "none",
                spinned: "spinner5",
                shadow: 0,
                hideTimerBar: "off",
                fullWidth: "off",
                fullScreen: "on",
                navigationStyle: "preview4"
            });
        });
    </script>
</asp:Content>

