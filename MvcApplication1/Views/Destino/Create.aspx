<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Destino>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Agregar Destinos
</asp:Content>

   
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
      @import url("http://www.google.com/uds/css/gsearch.css");
      @import url("http://www.google.com/uds/solutions/localsearch/gmlocalsearch.css");
    </style>

    <script src="../../MvcApplication1/Scripts/jquery-1.4.3.js"></script>
    <script src="../../MvcApplication1/Scripts/jquery.ui.core.js"></script>
    <script src="../../MvcApplication1/Scripts/jquery.ui.datepicker-es.js"></script>
    <script src="../../MvcApplication1/Scripts/jquery.ui.datepicker.js"></script>
    <script src="http://www.google.com/uds/api?file=uds.js&v=1.0&key=ABQIAAAAp0Kj6-TRULdy9KWugN_GfxTAdLk6fhpyuNdDdRr81ySzv4W5CRSHcX_iuexOywKZQSEdjN-rXx8BAA" type="text/javascript"></script>
    <script src="http://www.google.com/jsapi?key=ABQIAAAAp0Kj6-TRULdy9KWugN_GfxTAdLk6fhpyuNdDdRr81ySzv4W5CRSHcX_iuexOywKZQSEdjN-rXx8BAA" type="text/javascript"></script>
    <script src="../../MvcApplication1/Scripts/LocationsMap.js" type="text/javascript" ></script>
    <script src="http://www.google.com/uds/solutions/localsearch/gmlocalsearch.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../../MvcApplication1/Content/style.css">
    <script type="text/javascript">
        $(function () {
            $("#Fecha").datepicker();
        });
	</script>
  <br />
  <h2 id="mapName"></h2>
  <div id="map" style="width : 700px; height : 400px; margin : 0px; padding : 0px; float : left; margin-right:20px;"></div> 

    <%Html.BeginForm();{%>
    
    <div>
    <fieldset>
    <legend><%: ViewData["Message"] %></legend>
     <p>
       <label for="Name">Lugar:</label>
       <%= Html.TextBox("Name")%>
     </p>
     <input type="submit" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only ui-state-hover" value="Buscar" name="Button"/>
    </fieldset>
    </div>
    <% } %>
    
    <p id="info"></p>
    <div id="im_wrapper" class="im_wrapper">
    
     <%
         int f = 0, c = 0, d = 2;
         for (int i = 0; i < (ViewData.Count)-2; i++) { %>
            <div style="background-position:<%: f.ToString()+"px "+c.ToString()+ "px;" %>">
                <img src="<%: ViewData["Message" + i] %>" alt="" />
            </div>
     <%
             if (d != 7)
                f = f -50;
             else
             {
                 f = 0;
                 c = c - 50;
                 d = 1;
             }   
            d++;
        } %>
     </div>
      <form id="form1" runat="server">
    
    <%: Html.ValidationSummary(true)%>
    <% Html.BeginForm();{%>    

        <fieldset>
            <legend>Datos adicionales:</legend>
                 
            <div class="editor-field">
                <input type="hidden" name="Url" id="Url" />
            </div>

            <div class="editor-field">
                <input type="hidden" name="Estatus" value="Sugerido" />
            </div>

            <div class="editor-field">
                <input type="hidden" name="idViaje" value="<%: ViewData["idViaje"] %>" />
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Descripcion)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Descripcion)%>
                <%: Html.ValidationMessageFor(model => model.Descripcion,"*")%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Direccion)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Direccion)%>
                <%: Html.ValidationMessageFor(model => model.Direccion,"*")%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Fecha)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Fecha)%>
                <%: Html.ValidationMessageFor(model => model.Fecha,"*")%>
            </div>

            <div class="editor-label">
                <input type="submit" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only ui-state-hover" value="Agregar Destino" name="Button" />
            </div>
        </fieldset>

    <% } %>

    <div>
    <a title="Volver" href="<%= Url.Action("Index", "Destino") %>">
          <img src="<%= Url.Content("~/Content/atras.png") %>" height="25px" width="25px" /></a>
      <%=Html.ActionLink("Volver...", "Index", "Destino", new { idViaje = ViewData["idViaje"] }, null)%>   
    </div>
      </form>
      <div id="im_loading" class="im_loading"></div>
		<div id="im_next" class="im_next"></div>
		<div id="im_prev" class="im_prev"></div>
        
    <!-- The JavaScript -->
    
    <script src="../../MvcApplication1/Scripts/jquery.transform-0.9.1.min.js"></script>
        <script type="text/javascript">
            //Paul Irish smartresize : http://paulirish.com/2009/throttled-smartresize-jquery-event-handler/
            (function ($, sr) {
                // debouncing function from John Hann
                // http://unscriptable.com/index.php/2009/03/20/debouncing-javascript-methods/
                var debounce = function (func, threshold, execAsap) {
                    var timeout;
                    return function debounced() {
                        var obj = this, args = arguments;
                        function delayed() {
                            if (!execAsap)
                                func.apply(obj, args);
                            timeout = null;
                        };
                        if (timeout)
                            clearTimeout(timeout);
                        else if (execAsap)
                            func.apply(obj, args);
                        timeout = setTimeout(delayed, threshold || 100);
                    };
                }
                //smartresize
                jQuery.fn[sr] = function (fn) { return fn ? this.bind('resize', debounce(fn)) : this.trigger(sr); };
            })(jQuery, 'smartresize');
		</script>
        <script type="text/javascript">
            $(function () {
                //check if the user made the
                //mistake to open it with IE
                var ie = false;
                if ($.browser.msie)
                    ie = true;
                //flag to control the click event
                var flg_click = true;
                //the wrapper
                var $im_wrapper = $('#im_wrapper');
                //the thumbs
                var $thumbs = $im_wrapper.children('div');
                //all the images
                var $thumb_imgs = $thumbs.find('img');
                //number of images
                var nmb_thumbs = $thumbs.length;
                //image loading status
                var $im_loading = $('#im_loading');
                //the next and previous buttons
                var $im_next = $('#im_next');
                var $im_prev = $('#im_prev');
                //number of thumbs per line
                var per_line = 6;
                //number of thumbs per column
                var per_col = Math.ceil(nmb_thumbs / per_line)
                //index of the current thumb
                var current = -1;
                //mode = grid | single
                var mode = 'grid';
                //an array with the positions of the thumbs
                //we will use it for the navigation in single mode
                var positionsArray = [];
                for (var i = 0; i < nmb_thumbs; ++i)
                    positionsArray[i] = i;


                //preload all the images
                $im_loading.show();
                var loaded = 0;
                $thumb_imgs.each(function () {
                    var $this = $(this);
                    $('<img/>').load(function () {
                        ++loaded;
                        if (loaded == nmb_thumbs * 2)
                            start();
                    }).attr('src', $this.attr('src'));
                    $('<img/>').load(function () {
                        ++loaded;
                        if (loaded == nmb_thumbs * 2)
                            start();
                    }).attr('src', $this.attr('src').replace('/thumbs', ''));
                });

                //starts the animation
                function start() {
                    $im_loading.hide();
                    //disperse the thumbs in a grid
                    disperse();
                }

                //disperses the thumbs in a grid based on windows dimentions
                function disperse() {
                    if (!flg_click) return;
                    setflag();
                    mode = 'grid';
                    //center point for first thumb along the width of the window
                    var spaces_w = 600 / (per_line + 1);
                    //center point for first thumb along the height of the window
                    var spaces_h = 600 / (per_col + 1);
                    //let's disperse the thumbs equally on the page
                    $thumbs.each(function (i) {
                        var $thumb = $(this);
                        //calculate left and top for each thumb,
                        //considering how many we want per line
                        var left = (spaces_w * ((i % per_line) + 1) - $thumb.width() / 2) + 600;
                        var top = (spaces_h * (Math.ceil((i + 1) / per_line)) - $thumb.height() / 2) + 250;
                        //lets give a random degree to each thumb
                        var r = Math.floor(Math.random() * 41) - 20;
                        /*
                        now we animate the thumb to its final positions;
                        we also fade in its image, animate it to 115x115,
                        and remove any background image	of the thumb - this
                        is not relevant for the first time we call disperse,
                        but when changing from single to grid mode
                        */
                        if (ie)
                            var param = {
                                'left': left + 'px',
                                'top': top + 'px'
                            };
                        else
                            var param = {
                                'left': left + 'px',
                                'top': top + 'px',
                                'rotate': r + 'deg'
                            };
                        $thumb.stop()
						.animate(param, 700, function () {
						    if (i == nmb_thumbs - 1)
						        setflag();
						})
						.find('img')
						.fadeIn(700, function () {
						    $thumb.css({
						        'background-image': 'none'
						    });
						    $(this).animate({
						        'width': '115px',
						        'height': '115px',
						        'marginTop': '5px',
						        'marginLeft': '5px'
						    }, 150);
						});
                    });
                }

                //controls if we can click on the thumbs or not
                //if theres an animation in progress
                //we don't want the user to be able to click
                function setflag() {
                    flg_click = !flg_click
                }

                /*
                when we click on a thumb, we want to merge them
                and show the full image that was clicked.
                we need to animate the thumbs positions in order
                to center the final image in the screen. The
                image itself is the background image that each thumb
                will have (different background positions)
                If we are currently seeing the single image,
                then we want to disperse the thumbs again,
                and with this, showing the thumbs images.
                */
                $thumbs.bind('click', function () {
                    if (!flg_click) return;
                    setflag();

                    var $this = $(this);
                    current = $this.index();

                    if (mode == 'grid') {
                        mode = 'single';
                        //the source of the full image
                        var image_src = $this.find('img').attr('src').replace('/thumbs', '');
                        document.getElementById("Url").value = image_src;
                        $thumbs.each(function (i) {
                            var $thumb = $(this);
                            var $image = $thumb.find('img');
                            //first we animate the thumb image
                            //to fill the thumbs dimentions
                            $image.stop().animate({
                                'width': '100%',
                                'height': '100%',
                                'marginTop': '0px',
                                'marginLeft': '0px'
                            }, 150, function () {
                                //calculate the dimentions of the full image
                                var f_w = per_line * 50;
                                var f_h = per_col * 50;
                                var f_l = (600 / 2 - f_w / 2) + 730
                                var f_t = (600 / 2 - f_h / 2) + 200
                                /*
                                set the background image for the thumb
                                and animate the thumbs postions and rotation
                                */
                                if (ie)
                                    var param = {
                                        'left': f_l + (i % per_line) * 50 + 'px',
                                        'top': f_t + Math.floor(i / per_line) * 50 + 'px'
                                    };
                                else
                                    var param = {
                                        'rotate': '0deg',
                                        'left': f_l + (i % per_line) * 50 + 'px',
                                        'top': f_t + Math.floor(i / per_line) * 50 + 'px'
                                    };
                                $thumb.css({
                                    'background-image': 'url(' + image_src + ')'
                                }).stop()
								.animate(param, 1200, function () {
								    //insert navigation for the single mode
								    if (i == nmb_thumbs - 1) {
								        addNavigation();
								        setflag();
								    }
								});
                                //fade out the thumb's image
                                $image.fadeOut(700);
                            });
                        });
                    }
                    else {
                        setflag();
                        //remove navigation
                        removeNavigation();
                        //if we are on single mode then disperse the thumbs
                        disperse();
                    }
                });

                //removes the navigation buttons
                function removeNavigation() {
                    $im_next.stop().animate({ 'right': '-50px' }, 300);
                    $im_prev.stop().animate({ 'left': '-50px' }, 300);
                }

                //add the navigation buttons
                function addNavigation() {
                    $im_next.stop().animate({ 'right': '0px' }, 300);
                    $im_prev.stop().animate({ 'left': '0px' }, 300);
                }

                //User clicks next button (single mode)
                $im_next.bind('click', function () {
                    if (!flg_click) return;
                    setflag();

                    ++current;
                    var $next_thumb = $im_wrapper.children('div:nth-child(' + (current + 1) + ')');
                    if ($next_thumb.length > 0) {
                        var image_src = $next_thumb.find('img').attr('src').replace('/thumbs', '');
                        document.getElementById("Url").value = image_src;
                        var arr = Array.shuffle(positionsArray.slice(0));
                        $thumbs.each(function (i) {
                            //we want to change each divs background image
                            //on a different point of time
                            var t = $(this);
                            setTimeout(function () {
                                t.css({
                                    'background-image': 'url(' + image_src + ')'
                                });
                                if (i == nmb_thumbs - 1)
                                    setflag();
                            }, arr.shift() * 20);
                        });
                    }
                    else {
                        setflag();
                        --current;
                        return;
                    }
                });

                //User clicks prev button (single mode)
                $im_prev.bind('click', function () {
                    if (!flg_click) return;
                    setflag();
                    --current;
                    var $prev_thumb = $im_wrapper.children('div:nth-child(' + (current + 1) + ')');
                    if ($prev_thumb.length > 0) {
                        var image_src = $prev_thumb.find('img').attr('src').replace('/thumbs', '');
                        document.getElementById("Url").value = image_src;
                        var arr = Array.shuffle(positionsArray.slice(0));
                        $thumbs.each(function (i) {
                            var t = $(this);
                            setTimeout(function () {
                                t.css({
                                    'background-image': 'url(' + image_src + ')'
                                });
                                if (i == nmb_thumbs - 1)
                                    setflag();
                            }, arr.shift() * 20);
                        });
                    }
                    else {
                        setflag();
                        ++current;
                        return;
                    }
                });

                //on windows resize call the disperse function
                $(window).smartresize(function () {
                    removeNavigation()
                    disperse();
                });

                //function to shuffle an array
                Array.shuffle = function (array) {
                    for (
					var j, x, i = array.length; i;
					j = parseInt(Math.random() * i),
					x = array[--i], array[i] = array[j], array[j] = x
				);
                    return array;
                };
            });
        </script>
</asp:Content>

