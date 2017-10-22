$(document).ready(function () {


    // Add new input with associated 'remove' link when 'add' button is clicked.
    var lessonCounter = 0;
    var questionCounter = 0;
    var answerCounter = 0;
    $('#addLesson').click(function (e) {
        e.preventDefault();
        lessonCounter++;
       
        $("#lessonContent").append(
            '<div id="lesson' + lessonCounter + '">'
                            + '<div class="payment-info">'
                            + '<input type="hidden" id="lessonNumber' + lessonCounter + '" value="' + lessonCounter + '">'
                                + '<h3>Lesson ' + lessonCounter + ' title</h3>'
                                + '<input type="text" id="lessonTitle' + lessonCounter + '" placeholder="Lesson title">'
                            + '</div>'
                            + '<div class="payment-info">'
                               + ' <h3>estimated time</h3>'
                               + '<input type="number" id="lessonEstimatedTime' + lessonCounter + '" placeholder="estimated time per minute">'
                          + ' </div>'
                           + '<div class="col-md-12">'
                              + '<h3>Lesson description</h3>'
                               + '<div class="input-container">'
                                + '  <textarea name="message" id="lessonDescription' + lessonCounter + '" placeholder="add the lesson description"></textarea>'
                              + ' </div>'
                           + ' </div>'
                           + '<div id="questionContent' + lessonCounter + '">'
                            + '</div>'
                             + '   <a href="javascript:;" id="cancelQuestion' + lessonCounter + '" class="btn-filled-rounded"> Cancel a question</a>'
                              + '  <a href="javascript:;" id="addQuestion' + lessonCounter + '" class="btn-filled-rounded"> Add a question</a>'


                           + ' </div>'

                            );
        //////////////////////QUESTION///////////////////////////////////
        var innerQuestionCounter = 0;
        var lessonNumber = $('#lessonNumber' + lessonCounter).val();

        $('#addQuestion' + lessonCounter).click(function (e) {
            e.preventDefault();
            questionCounter++;
            innerQuestionCounter++;
           
            $("#questionContent" + lessonNumber).append(
                '<div id="question' + questionCounter + '">'
               + '<div class="payment-info">'
                + '<input type="hidden" id="questionNumber' + questionCounter + '" value="' + questionCounter + '">'
                                     + '<input type="hidden" id="questionLessonId' + questionCounter + '" value="' + lessonNumber + '">'
                                    + '<h3>question ' + innerQuestionCounter + ' title</h3>'
                                    + '<input type="text" id="questionTitle' + questionCounter + '" placeholder="Question title">'
                                + '</div>'

                               + '<div class="col-md-12">'
                                  + '<h3>Question description</h3>'
                                   + '<div class="input-container">'
                                    + '  <textarea name="message" id="questionDescription' + questionCounter + '" placeholder="add the question description"></textarea>'
                                  + ' </div>'
                               + ' </div>'
                                + '<div id="answerContent' + questionCounter + '">'
                            + '</div>'
                                + '   <a href="javascript:;" id="cancelAnswer' + questionCounter + '" class="btn-filled-rounded"> Cancel an answer</a>'
                              + '  <a href="javascript:;" id="addAnswer' + questionCounter + '" class="btn-filled-rounded"> Add an answer</a>'
                               + ' </div>'

                                );

            //////////////////////Answer///////////////////////////////////
            var innerAnswerCounter = 0;
            var questionNumber = $('#questionNumber' + questionCounter).val();

            $('#addAnswer' + questionCounter).click(function (e) {
                e.preventDefault();
                answerCounter++;
                innerAnswerCounter++;
                
                $("#answerContent" + questionNumber).append(
                    '<div id="answer' + answerCounter + '">'
                   + '<div class="payment-info">'
                                         + '<input type="hidden" id="answerQuestionId' + answerCounter + '" value="' + questionNumber + '">'
                                        + '<h3>answer ' + innerAnswerCounter + ' title</h3>'

                                    + '</div>'
                                   + '<div class="btn-group" data-toggle="buttons">'
                                + '<label class="btn donate-btn active">'
                                 + '   <input type="radio" name="trueAnswer" id="true1" value="0" autocomplete="off" checked> True answer'
                                + '</label>'
                                + '<label class="btn donate-btn">'
                                 + '   <input type="radio" name="trueAnswer" id="true2" value="1" autocomplete="off"> wrong answer'
                                + '</label>'
                            + '</div>'
                                   + '<div class="col-md-12">'
                                      + '<h3>Answer description</h3>'
                                       + '<div class="input-container">'
                                        + '  <textarea name="message" id="answerDescription' + answerCounter + '" placeholder="add the answer description"></textarea>'
                                      + ' </div>'
                                   + ' </div>'
                                   + ' </div>'

                                    );

            });

            // Remove parent of 'remove' link when link is clicked.
            $('#cancelAnswer' + questionCounter).on('click', function (e) {
                e.preventDefault();
                $("#answer" + answerCounter).remove();
                answerCounter--;
                innerAnswerCounter--;
            });


            ////////////////END Answer////////////////////////////////////





        });

        // Remove parent of 'remove' link when link is clicked.
        $('#cancelQuestion' + lessonCounter).on('click', function (e) {
            e.preventDefault();
            $("#question" + questionCounter).remove();
            questionCounter--;
            innerQuestionCounter--;
        });


        ////////////////END QUESTION////////////////////////////////////




    });

    // Remove parent of 'remove' link when link is clicked.
    $('#cancelLesson').on('click', function (e) {
        e.preventDefault();
        $("#lesson" + lessonCounter).remove();
        lessonCounter--;
    });

























    $("#btnSave").on('click', function () {
        var title = $('#trainingTitle').val();
        var description = $('#trainingDescription').val();
        var estimatedTime = $('#trainingEstimatedTime').val();
        var difficultyValue = $(":input[name=difficulty]:checked").val();
        var difficultyDescription = $('#difficultyDescription').val();

        var lessonData = [];
        var questionData = [];
        var answerData = [];

        for (i = 1; i <= lessonCounter; i++) {

            var titlel = $('#lessonTitle' + i).val();
            var descriptionl = $('#lessonDescription' + i).val();
            var estimatedTimel = $('#lessonEstimatedTime' + i).val();
            console.log("indice i :" + i);
            console.log("titre lesson : " + titlel);
            console.log("description lesson : " + descriptionl);
            console.log("estimated time lesson : " + estimatedTimel);
            /////// add questions to questionData////////////
            for (var j = 1; j <= questionCounter; j++) {
                var testQLParam = $('#questionLessonId' + j).val();

                if (testQLParam == i) {
                    var titleq = $('#questionTitle' + j).val();
                    var descriptionq = $('#questionDescription' + j).val();
                    console.log("indice j:" + j);
                    console.log("titre question :" + titleq);
                    console.log("description question :" + descriptionq);
                    console.log("key question : "+testQLParam);
                    //ADD ANSWERS TO ANSWERSDATA
                    for (var k = 1; k <= answerCounter; k++) {
                        var testAQParam = $('#answerQuestionId' + k).val();
                        var isTruea = $(":input[name=trueAnswer]:checked").val();
                        if (testAQParam == j) {
                            var descriptiona = $('#answerDescription' + k).val();
                            console.log("indice k :" + k);
                            console.log("description k :" + descriptiona);
                            console.log("key answer :" + testAQParam);

                            answerData.push(
                          {
                              description: descriptiona,
                              questionNumber: testAQParam,
                              isTrue: isTruea,
                          }

                         );
                        }
                    }
                    questionData.push(
                  {
                      title: titleq,
                      description: descriptionq,
                      lessonNumber: testQLParam,
                      questionNumber: j,
                  }

                 );
                }
            }


            lessonData.push(
                  {
                      title: titlel,
                      description: descriptionl,
                      estimatedTime: estimatedTimel,
                      lessonNumber: i,
                  }

                 );
        }

        console.log("lesson data : " + lessonData);
        console.log("question data : " + questionData);
        console.log("answer data : " + answerData);
        $.ajax({
            url: "/Training/CreateTraining",
            type: "POST",
            ContentType: 'application/json;charset=utf-8',
            data: {
                "t": {
                    "title": title,
                    "description": description,
                    "estimatedTime": estimatedTime,
                    "difficultyValue": difficultyValue,
                    "difficultyDescription": difficultyDescription,
                },
                "l": lessonData,
                "q": questionData,
                "a": answerData
            },
            datatype: 'json'
        }).success(function (data) {
            
            alert('Success ' + data);
        }).error(function (err) {
            alert("Error " + err.status);
        });


    });

});