$(() => {
    var $reportContainer = $('#reportContainer');

    var reportUrl = 'http://powerbipaasapi.azurewebsites.net/api/reports/63f50faa-f1fe-40ed-ab33-67fb09b80251';

    fetch(reportUrl)
        .then(response => response.json())
        .then(report => {
            var reportConfig = $.extend({ type: 'report' }, report);
            $reportContainer.powerbi(reportConfig);
        });
});

// Write your Javascript code.
