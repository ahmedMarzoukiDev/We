$(document).ready(function () {


    // Add new input with associated 'remove' link when 'add' button is clicked.
    var lessonCounter = 0;
    var questionCounter = 0;
    $('#addLesson').click(function (e) {
        e.preventDefault();
        lessonCounter++;
        alert(lessonCounter);
        $("#lessonContent").append(
            '<div id="lesson' + lessonCounter + '">'
           + '<div class="payment-info">'
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
                             +'   <a href="javascript:;" id="cancelQuestion'+lessonCounter+'" class="btn-filled-rounded"> Cancel a question</a>'
                              +'  <a href="javascript:;" id="addQuestion'+lessonCounter+'" class="btn-filled-rounded"> Add a question</a>'
                           
                            +'<div id="questionContent'+lessonCounter+'">'
                            +'</div>'
                           + ' </div>'

                            );
        //////////////////////QUESTION///////////////////////////////////
        var innerQuestionCounter = 0;
        $('#addQuestion'+lessonCounter).click(function (e) {
            e.preventDefault();
            questionCounter++;
            innerQuestionCounter++;
            alert(questionCounter);
            $("#lessonContent").append(
                '<div id="question' + questionCounter + '">'
               + '<div class="payment-info">'
                                    + '<h3>question ' + innerQuestionCounter + ' title</h3>'
                                    + '<input type="text" id="questionTitle' + questionCounter + '" placeholder="Question title">'
                                + '</div>'
                               
                               + '<div class="col-md-12">'
                                  + '<h3>Question description</h3>'
                                   + '<div class="input-container">'
                                    + '  <textarea name="message" id="questionDescription' + questionCounter + '" placeholder="add the question description"></textarea>'
                                  + ' </div>'
                               + ' </div>'
                               + ' </div>'

                                );
          
        });

        // Remove parent of 'remove' link when link is clicked.
        $('#cancelQuestion'+lessonCounter).on('click', function (e) {
            e.preventDefault();
            $("#question" + questionCounter).remove();
            questionCounter--;
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
        for (i = 1; i <= lessonCounter; i++) {
            var titlel = $('#lessonTitle' + i).val();
            var descriptionl = $('#lessonDescription' + i).val();
            var estimatedTimel = $('#lessonEstimatedTime' + i).val();
            alert(titlel);
            lessonData.push(
                  {
                      title: titlel,
                      description: descriptionl,
                      estimatedTime: estimatedTimel,
                  }
                 
                 );
        }
        
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
                "l":lessonData,
            },
            datatype: 'json'
        }).success(function (data) {
            $('html').html(data);
            alert('Success ' + data);
        }).error(function (err) {
            alert("Error " + err.status);
        });


    });

});