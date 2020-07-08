$(document).ready(function () {
    var itemsMainDiv = ('.MultiCarousel');
    var itemsDiv = ('.MultiCarousel-inner');
    var itemWidth = "";

    $('.leftLst, .rightLst').click(function () {
        var condition = $(this).hasClass("leftLst");
        if (condition)
            click(0, this);
        else
            click(1, this);
    });

    ResCarouselSize();

    $(window).resize(function () {
        ResCarouselSize();
    });

    //esta funcion define el tamaño de los items 
    function ResCarouselSize() {
        var incno = 0;
        var dataItems = ("data-items");
        var itemClass = ('.item');
        var id = 0;
        var btnParentSb = '';
        var itemsSplit = '';
        var sampwidth = $(itemsMainDiv).width();
        var bodyWidth = $('body').width();
        $(itemsDiv).each(function () {
            id = id + 1;
            var itemNumbers = $(this).find(itemClass).length;
            btnParentSb = $(this).parent().attr(dataItems);
            itemsSplit = btnParentSb.split(',');
            $(this).parent().attr("id", "MultiCarousel" + id);


            if (bodyWidth >= 1200) {
                incno = itemsSplit[3];
                itemWidth = sampwidth / incno;
            }
            else if (bodyWidth >= 992) {
                incno = itemsSplit[2];
                itemWidth = sampwidth / incno;
            }
            else if (bodyWidth >= 768) {
                incno = itemsSplit[1];
                itemWidth = sampwidth / incno;
            }
            else {
                incno = itemsSplit[0];
                itemWidth = sampwidth / incno;
            }
            $(this).css({ 'transform': 'translateX(0px)', 'width': itemWidth * itemNumbers });
            $(this).find(itemClass).each(function () {
                $(this).outerWidth(itemWidth);
            });

            $(".leftLst").addClass("over");
            $(".rightLst").removeClass("over");

        });
    }


    //this function used to move the items
    function ResCarousel(e, el, s) {
        var leftBtn = ('.leftLst');
        var rightBtn = ('.rightLst');
        var translateXval = '';
        var divStyle = $(el + ' ' + itemsDiv).css('transform');
        var values = divStyle.match(/-?[\d\.]+/g);
        var xds = Math.abs(values[4]);
        if (e === 0) {
            translateXval = parseInt(xds) - parseInt(itemWidth * s);
            $(el + ' ' + rightBtn).removeClass("over");

            if (translateXval <= itemWidth / 2) {
                translateXval = 0;
                $(el + ' ' + leftBtn).addClass("over");
            }
        }
        else if (e === 1) {
            var itemsCondition = $(el).find(itemsDiv).width() - $(el).width();
            translateXval = parseInt(xds) + parseInt(itemWidth * s);
            $(el + ' ' + leftBtn).removeClass("over");

            if (translateXval >= itemsCondition - itemWidth / 2) {
                translateXval = itemsCondition;
                $(el + ' ' + rightBtn).addClass("over");
            }
        }
        $(el + ' ' + itemsDiv).css('transform', 'translateX(' + -translateXval + 'px)');
    }

    //It is used to get some elements from btn
    function click(ell, ee) {
        var Parent = "#" + $(ee).parent().attr("id");
        var slide = $(Parent).attr("data-slide");
        ResCarousel(ell, Parent, slide);
    }


    //scripts inmueble form

    FileDelet("#img1Del", "#file-preview-img1", "#img1");
    FileDelet("#img2Del", "#file-preview-img2", "#img2");
    FileDelet("#img3Del", "#file-preview-img3", "#img3");
    FileDelet("#img4Del", "#file-preview-img4", "#img4");
    FileDelet("#img5Del", "#file-preview-img5", "#img5");
    FileDelet("#img6Del", "#file-preview-img6", "#img6");
    FileDelet("#img7Del", "#file-preview-img7", "#img7");
    FileDelet("#img8Del", "#file-preview-imm8", "#img8");
    FileDelet("#img9Del", "#file-preview-img9", "#img9");
    FileDelet("#img10Del", "#file-preview-imm10", "#img10");
    FileDelet("#img11Del", "#file-preview-img11", "#img11");
    FileDelet("#img12Del", "#file-preview-img12", "#img12");
    FileDelet("#img13Del", "#file-preview-img13", "#img13");
    FileDelet("#img14Del", "#file-preview-img14", "#img14");
    FileDelet("#img15Del", "#file-preview-img15", "#img15");
    FileDelet("#img16Del", "#file-preview-img16", "#img16");
    FileDelet("#img17Del", "#file-preview-img17", "#img17");
    FileDelet("#img18Del", "#file-preview-imm18", "#img18");
    FileDelet("#img19Del", "#file-preview-img19", "#img19");
    FileDelet("#img20Del", "#file-preview-imm20", "#img20");



    function FileDelet(idB, idIV, idInmput) {
        $(function () {
            $(idB).click(function () {
                $(idIV).html("");
                $(idInmput).val("");
                //ajax
                $.ajax({
                    url: "/Inmueble/DelImg?idImag=" + $(this).attr("value"),
                    method: "post",
                    success: function (data, status) {
                        if (data === true) {
                            console.log("se ha eliminado la imagen");
                        }
                        else {
                            console.log("no se ha eliminado");
                        }
                    }
                });



            });
        });
    }

    function filepreviewimg(input, dato) {
        if (input.files && input.files[0]) {
            var read = new FileReader();
            read.onload = function (e) {
                $(dato).html("<img src='" + e.target.result + "'/>");

            };

        } read.readAsDataURL(input.files[0]);
    };

    $('#img1').change(function () { filepreviewimg(this, "#file-preview-img1"); });
    $('#img2').change(function () { filepreviewimg(this, "#file-preview-img2"); });
    $('#img3').change(function () { filepreviewimg(this, "#file-preview-img3"); });
    $('#img4').change(function () { filepreviewimg(this, "#file-preview-img4"); });
    $('#img5').change(function () { filepreviewimg(this, "#file-preview-img5"); });
    $('#img6').change(function () { filepreviewimg(this, "#file-preview-img6"); });
    $('#img7').change(function () { filepreviewimg(this, "#file-preview-img7"); });
    $('#img8').change(function () { filepreviewimg(this, "#file-preview-img8"); });
    $('#img9').change(function () { filepreviewimg(this, "#file-preview-img9"); });
    $('#img10').change(function () { filepreviewimg(this, "#file-preview-img10"); });
    $('#img11').change(function () { filepreviewimg(this, "#file-preview-img11"); });
    $('#img12').change(function () { filepreviewimg(this, "#file-preview-img12"); });
    $('#img13').change(function () { filepreviewimg(this, "#file-preview-img13"); });
    $('#img14').change(function () { filepreviewimg(this, "#file-preview-img14"); });
    $('#img15').change(function () { filepreviewimg(this, "#file-preview-img15"); });
    $('#img16').change(function () { filepreviewimg(this, "#file-preview-img16"); });
    $('#img17').change(function () { filepreviewimg(this, "#file-preview-img17"); });
    $('#img18').change(function () { filepreviewimg(this, "#file-preview-img18"); });
    $('#img19').change(function () { filepreviewimg(this, "#file-preview-img19"); });
    $('#img20').change(function () { filepreviewimg(this, "#file-preview-img20"); });


    $(function () {
        $("#AlquilerID").change(function () {
            var st = this.checked;
            if (st) {
                $("#PrecioAlquilerInm").prop("hidden", false);
                $("#LabPrecioAlquilerInm").prop("hidden", false);
            } else {
                $("#PrecioAlquilerInm").prop("hidden", true);
                $("#LabPrecioAlquilerInm").prop("hidden", true);
            }
        });
        $("#VentaID").change(function () {
            var st = this.checked;
            if (st) {
                $("#PrecioVentaInm").prop("hidden", false);
                $("#LabPrecioVentaInm").prop("hidden", false);
            } else {
                $("#PrecioVentaInm").prop("hidden", true);
                $("#LabPrecioVentaInm").prop("hidden", true);
            }
        });
    });
    $(function () {
        if ($("#IdInmuebleTip").val() === "1") {
            $("#NumHabitaciones").prop("hidden", false);
            $("#Pisos").prop("hidden", false);
            $("#Piso").prop("hidden", true);
            $("#LabNumHabitaciones").prop("hidden", false);
            $("#LabPisos").prop("hidden", false);
            $("#LabPiso").prop("hidden", true);
            $("#Baños").prop("hidden", false);
            $("#LabBaños").prop("hidden", false);
            $("#Garages").prop("hidden", false);
            $("#LabGarages").prop("hidden", false);
        }
        if ($("#IdInmuebleTip").val() === "2") {
            $("#NumHabitaciones").prop("hidden", false);
            $("#Pisos").prop("hidden", true);
            $("#Piso").prop("hidden", false);
            $("#LabNumHabitaciones").prop("hidden", false);
            $("#LabPisos").prop("hidden", true);
            $("#LabPiso").prop("hidden", false);
            $("#Baños").prop("hidden", false);
            $("#LabBaños").prop("hidden", false);
            $("#Garages").prop("hidden", false);
            $("#LabGarages").prop("hidden", false);
        }
        if ($("#IdInmuebleTip") === "3") {
            $("#NumHabitaciones").prop("hidden", true);
            $("#Pisos").prop("hidden", true);
            $("#Piso").prop("hidden", false);
            $("#LabNumHabitaciones").prop("hidden", true);
            $("#LabPisos").prop("hidden", true);
            $("#LabPiso").prop("hidden", false);
            $("#Baños").prop("hidden", true);
            $("#LabBaños").prop("hidden", true);
            $("#Garages").prop("hidden", true);
            $("#LabGarages").prop("hidden", true);
        }
        if ($("#IdInmuebleTip") === "4") {
            $("#NumHabitaciones").prop("hidden", true);
            $("#Pisos").prop("hidden", true);
            $("#Piso").prop("hidden", true);
            $("#LabNumHabitaciones").prop("hidden", true);
            $("#LabPisos").prop("hidden", true);
            $("#LabPiso").prop("hidden", true);
            $("#Baños").prop("hidden", true);
            $("#LabBaños").prop("hidden", true);
            $("#Garages").prop("hidden", true);
            $("#LabGarages").prop("hidden", true);
        }
        if ($("#IdInmuebleTip") === "5") {
            $("#NumHabitaciones").prop("hidden", false);
            $("#Pisos").prop("hidden", false);
            $("#Piso").prop("hidden", true);
            $("#LabNumHabitaciones").prop("hidden", false);
            $("#LabPisos").prop("hidden", false);
            $("#LabPiso").prop("hidden", true);
            $("#Baños").prop("hidden", false);
            $("#LabBaños").prop("hidden", false);
            $("#Garages").prop("hidden", true);
            $("#LabGarages").prop("hidden", true);
        }
        if ($("#IdInmuebleTip") === "6") {
            $("#NumHabitaciones").prop("hidden", true);
            $("#Pisos").prop("hidden", true);
            $("#Piso").prop("hidden", false);
            $("#LabNumHabitaciones").prop("hidden", true);
            $("#LabPisos").prop("hidden", true);
            $("#LabPiso").prop("hidden", false);
            $("#Baños").prop("hidden", false);
            $("#LabBaños").prop("hidden", false);
            $("#Garages").prop("hidden", true);
            $("#LabGarages").prop("hidden", true);
        }
        if ($("#IdInmuebleTip") === "0") {
            $("#NumHabitaciones").prop("hidden", true);
            $("#Pisos").prop("hidden", true);
            $("#Piso").prop("hidden", true);
            $("#LabNumHabitaciones").prop("hidden", true);
            $("#LabPisos").prop("hidden", true);
            $("#LabPiso").prop("hidden", true);
            $("#Baños").prop("hidden", true);
            $("#LabBaños").prop("hidden", true);
            $("#Garages").prop("hidden", true);
            $("#LabGarages").prop("hidden", true);
        }
    });
    $(function () {
        $("#IdInmuebleTip").change(function () {
            if ($(this).val() === "1") {
                $("#NumHabitaciones").prop("hidden", false);
                $("#Pisos").prop("hidden", false);
                $("#Piso").prop("hidden", true);
                $("#LabNumHabitaciones").prop("hidden", false);
                $("#LabPisos").prop("hidden", false);
                $("#LabPiso").prop("hidden", true);
                $("#Baños").prop("hidden", false);
                $("#LabBaños").prop("hidden", false);
                $("#Garages").prop("hidden", false);
                $("#LabGarages").prop("hidden", false);
            } if ($(this).val() === "2") {
                $("#NumHabitaciones").prop("hidden", false);
                $("#Pisos").prop("hidden", true);
                $("#Piso").prop("hidden", false);
                $("#LabNumHabitaciones").prop("hidden", false);
                $("#LabPisos").prop("hidden", true);
                $("#LabPiso").prop("hidden", false);
                $("#Baños").prop("hidden", false);
                $("#LabBaños").prop("hidden", false);
                $("#Garages").prop("hidden", false);
                $("#LabGarages").prop("hidden", false);
            } if ($(this).val() === "3") {
                $("#NumHabitaciones").prop("hidden", true);
                $("#Pisos").prop("hidden", true);
                $("#Piso").prop("hidden", false);
                $("#LabNumHabitaciones").prop("hidden", true);
                $("#LabPisos").prop("hidden", true);
                $("#LabPiso").prop("hidden", false);
                $("#Baños").prop("hidden", true);
                $("#LabBaños").prop("hidden", true);
                $("#Garages").prop("hidden", true);
                $("#LabGarages").prop("hidden", true);
            } if ($(this).val() === "4") {
                $("#NumHabitaciones").prop("hidden", true);
                $("#Pisos").prop("hidden", true);
                $("#Piso").prop("hidden", true);
                $("#LabNumHabitaciones").prop("hidden", true);
                $("#LabPisos").prop("hidden", true);
                $("#LabPiso").prop("hidden", true);
                $("#Baños").prop("hidden", true);
                $("#LabBaños").prop("hidden", true);
                $("#Garages").prop("hidden", true);
                $("#LabGarages").prop("hidden", true);
            } if ($(this).val() === "5") {
                $("#NumHabitaciones").prop("hidden", false);
                $("#Pisos").prop("hidden", false);
                $("#Piso").prop("hidden", true);
                $("#LabNumHabitaciones").prop("hidden", false);
                $("#LabPisos").prop("hidden", false);
                $("#LabPiso").prop("hidden", true);
                $("#Baños").prop("hidden", false);
                $("#LabBaños").prop("hidden", false);
                $("#Garages").prop("hidden", true);
                $("#LabGarages").prop("hidden", true);
            } if ($(this).val() === "6") {
                $("#NumHabitaciones").prop("hidden", true);
                $("#Pisos").prop("hidden", true);
                $("#Piso").prop("hidden", false);
                $("#LabNumHabitaciones").prop("hidden", true);
                $("#LabPisos").prop("hidden", true);
                $("#LabPiso").prop("hidden", false);
                $("#Baños").prop("hidden", false);
                $("#LabBaños").prop("hidden", false);
                $("#Garages").prop("hidden", true);
                $("#LabGarages").prop("hidden", true);
            }
            if ($(this).val() === "0") {
                $("#NumHabitaciones").prop("hidden", true);
                $("#Pisos").prop("hidden", true);
                $("#Piso").prop("hidden", true);
                $("#LabNumHabitaciones").prop("hidden", true);
                $("#LabPisos").prop("hidden", true);
                $("#LabPiso").prop("hidden", true);
                $("#Baños").prop("hidden", true);
                $("#LabBaños").prop("hidden", true);
                $("#Garages").prop("hidden", true);
                $("#LabGarages").prop("hidden", true);
            }

        });
    });


    //seccion para imagen de perfil
    $('#imgperfil').change(function () { filepreviewimgP(this, "#preview_imgPerfil"); });

    FileDeletImgP("#imgperfilDel", "#preview_imgPerfil", "#imgperfil");



    function FileDeletImgP(idB, idIV, idInmput) {
        $(function () {
            $(idB).click(function () {
              
                $("#ImgPerfil1").attr("src", "https://d500.epimg.net/cincodias/imagenes/2016/07/04/lifestyle/1467646262_522853_1467646344_noticia_normal.jpg");
                //ajax
             
            });
        });
    }
    function filepreviewimgP(input, dato) {
        if (input.files && input.files[0]) {
            var read = new FileReader();
            read.onload = function (e) {
                $(dato).html("<img id=ImgPerfil1 src='" + e.target.result + "'/>");

            };

        } read.readAsDataURL(input.files[0]);
    }

    //$.on("#btn_Prueba_xd").click(
    //    function () {
    //        $.ready({
    //            source: function (request, response) {
    //                $.ajax({
    //                    url: "/Inmueble/InmLayout",
    //                    dataType: "json",
    //                    method: "get",
    //                    success: function (dat) {
    //                        response($.map(dat, function (item) {
    //                            return item;
    //                        }
    //                        ));
    //                    }
    //                });
    //            },

    //        }
    //        );
    //        //$("#lblprueba").text("suputamadre");
    //        //var dato = $.getJSON("/Inmueble/InmLayout", { format: "json" }).done(function (data) { });
    //        var dato = $.getJSON("/Inmueble/InmLayout", dat, success).done(function (dat) { $("#lblprueba").text("done funciona"); });
    //        dato.forEach(function (dat) {
    //            if (dat.InmuebleId === 2) {
    //                $("#lblprueba").text("each funciona");
    //            }
    //        });
    //        if (dato !== null) {
    //            $("#lblprueba1").text("suputamadre1");
    //        }
    //    }
    //);



    //////////////////////////////////////////////////////////////////////////////////////
    //$().onload(
    //    //$.ajax({
    //    //    url: "/Inmueble/InmLayout",
    //    //    dataType: 'json', // added data type
    //    //    method: "get",
    //    //    success: function (dat) {
    //    //        console.log(dat);
    //    //        alert(dat);
    //    //        $("#lblprueba").text("Ajax Funciona" );
    //    //    }
    //    //})
    //    $.getJSON("/Inmueble/InmLayout", {
    //        tags: "mount rainier",
    //        tagmode: "any",
    //        format: "json"
    //    }).done(function (dat) {
    //            $.each(dat.items, function (i, item) {
    //                $("#lblprueba").text("xdddddddddddddddd");

    //            });
    //        })

    //);


    ////////////////////////////////////////////////////////////////////////////
//$("#btn_Prueba_xd").ready(function () {});

//        }).click(function () {

//        var data = $.ajax({
//            url: "/Inmueble/InmLayout",
//            dataType: 'json',
//            method: "get",
//            success: function (dat) {
//                $("#lblprueba").text("Ajax Funciona");
//                return dat;
//                //console.log(dat);

//                //$.each(dat, function (index, elemento) {
//                //    $("#lblprueba").text(dat.Img);
//                //    $("#lblprueba").text(dat[index].Img);
//                //    $("#lblprueba").text(elemento.Img);
//                //
//                }
//            });
       
//        //var xd;
//        //for (var item in data) {
//        //if (item.InmuebleId === 2) {
//        //    xd = item.Img;
//        //    $("#lblprueba").text("each funciona");
//        //} else { $("#lblprueba2").text("si funciona el each");}
//        //    } 


//        //$.each(data, function (dat) {
//        //    if (dat.InmuebleId === 2) {
//        //        xd = dat.Img;
//        //        //$("#lblprueba").text("each funciona");
//        //    } else { $("#lblprueba2").text("si funciona el each");}
//        //}); 
//        //$("#lblprueba").text("data:  " + data);
//        $("#lblprueba1").text("item:  " + xd);
   
//        //});
//    //$("#lblprueba1").text("prueba");
    app();
 
});


var url = "/Inmueble/InmLayout";
var urlUsers = 'https://jsonplaceholder.typicode.com/users';
var app = new Vue({
    el: '#main',
    created: function () {
        this.getInm();
        //this.cantidadImagenes();
    },
    data: {
        lists: [],
        temp: 0,
    },
    methods: {
        getInm: function () {
            this.$http.get(url).then(function (response) {
                this.lists = response.data;
            });
        }

    },
    computed: {
        cantidadImagenes: function () {
            this.temp = 0;
            for (itms of this.lists) {
                this.temp++;
            }
            return this.temp;
        }
    }
});
 