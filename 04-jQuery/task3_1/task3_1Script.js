// JavaScript source code
var TestBase = {
    curQuestionNum : 0,
    questions: [["removeAttr()", "Функция для удаления атрибута"],
                ["empty()", "Функция, которая удаляет подэлементы селектора"],
                ["append()", "Функция для добавления подэлементов"]],
    variants: [["removeAttr()", "removeProp()", "getAttr()"],
              ["empty()", "remove()", "delete()"],
              ["append()", "innerHTML()"]],
    userAnswers: [],
    result: 0,
    passRate: 0.5,
    getCurQuestion: function () {
        var question = this.questions[this.curQuestionNum][1];
        this.curQuestionNum++;
        return question;
    },

}
// for changing order of variants
Array.prototype.shuffle = function () {
    var i = this.length, j, tmp;
    if (i == 0) { return this; }
    while (--i) {
        j = Math.floor(Math.random() * (i + 1));
        tmp = this[i]; this[i] = this[j]; this[j] = tmp;
    }
    return this;
}

$(document).ready(function () {
    $('button#start').click(function () {
        $(this).html("Submit");
        if (typeof ($("input:checked").val()) !== "undefined") {
            TestBase.userAnswers[TestBase.curQuestionNum - 1] = $("input:checked").val();
        }
        var curVariants =  TestBase.variants[TestBase.curQuestionNum];
        if (TestBase.curQuestionNum < TestBase.variants.length) {
            $("#question").html(TestBase.getCurQuestion());
            $(".answers").empty();
            curVariants.shuffle();
            for (var i = 0; i < curVariants.length; i++) {
                $(".answers").append("<li><input type='radio' name='answers' value='"+i+"'/><label for='"+i+"'>" + curVariants[i] + "</label></li>");
            }
        }
        else {
            $("div#testbody").empty();
            for (var i = 0; i < TestBase.questions.length; i++) {
                $("div#testbody").append(TestBase.questions[i][1] + "<br/>");
                $("div#testbody").append("<ol id='list" + i + "'class='answers'>");
                for (var j = 0; j < TestBase.variants[i].length; j++) {
                    if (j == TestBase.userAnswers[i])
                    {
                        if (TestBase.variants[i][j] === TestBase.questions[i][0])
                        {
                            $("ol#list" + i).append("<li class='right'><input type='radio' name='answers"+i+"' checked disabled/>" + TestBase.variants[i][j] + "</li>");
                            TestBase.result++;
                        }
                        else {
                            $("ol#list" + i).append("<li class='wrong'><input type='radio' name='answers" + i + "' checked disabled/>" + TestBase.variants[i][j] + "</li>");
                        }
                    }
                    else
                        $("ol#list" + i).append("<li><input type='radio' name='answers" + i + "' disabled/>" + TestBase.variants[i][j] + "</li>");
                }
            }
            $('div#testbody').append("<span>Результат: " + TestBase.result + "/" + TestBase.questions.length + "</span>");
            if (TestBase.result / TestBase.questions.length > TestBase.passRate)
            {
                $('div#testbody').append("<span class='right'>Пройдено</span>");
            }
            else
            {
                $('div#testbody').append("<span class='wrong'>Не пройдено</span>");
            }
            $("button#exit").removeAttr('hidden');
        }
    });
    $('button#exit').click(function () {
        location.reload();
    });

});