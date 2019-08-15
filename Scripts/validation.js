var me2youValidation = {

    createNewEventValidateAndSubmit : function() {
        //  Validate input fields and submit form
        var validationCount = 0;
        var venue = $('#venue').val();
        var category = $('#category-id').val();
        var name = $('#event-name').val();
        var date = $('#event-date').val();
        var quantity = $('#ticket-quantity').val();
        var claims = $('#max-claims').val();
        var eventDate = new Date(date).getTime();
        var todaysDate = Date.now();

        if (venue.length <= 0) {
            $('#venue-warning').show();
        } else {
            $('#venue-warning').hide();
            validationCount++;
        }

        if (category.length <= 0) {
            $('#category-warning').show();
        } else {
            $('#category-warning').hide();
            validationCount++;
        }

        if (name.length <= 0) {
            $('#event-name-warning').show();
        } else {
            $('#event-name-warning').hide();
            validationCount++;
        }

        if (date.length <= 0) {
            $('#event-date-warning').show();
            $('#event-date-passed-warning').hide();
        } else if (eventDate < todaysDate) {
            $('#event-date-warning').hide();
            $('#event-date-passed-warning').show();
        } else {
            $('#event-date-warning').hide();
            $('#event-date-passed-warning').hide();
            validationCount++;
        }


        var regex = /[0-9]|\./;
        if (quantity.length <= 0) {
            $('#quantity-warning').show();
            $('#quantity-format-warning').hide();
            $('#quantity-negative-number-warning').hide();
        } else if (!regex.test(quantity)) {
            $('#quantity-format-warning').show();
            $('#quantity-warning').hide();
            $('#quantity-negative-number-warning').hide();
        } else if (quantity <= 0) {
            $('#quantity-warning').hide();
            $('#quantity-format-warning').hide();
            $('#quantity-negative-number-warning').show();
        }
        else {
            $('#quantity-format-warning').hide();
            $('#quantity-warning').hide();
            $('#quantity-negative-number-warning').hide();
            validationCount++;
        }

        if (claims.length <= 0) {
            $('#claims-warning').show();
            $('#claims-format-warning').hide();
            $('#claims-negative-number-warning').hide();
        } else if (!regex.test(claims)) {
            $('#claims-format-warning').show();
            $('#claims-warning').hide();
            $('#claims-negative-number-warning').hide();
        } else if (claims <= 0) {
            $('#claims-warning').hide();
            $('#claims-format-warning').hide();
            $('#claims-negative-number-warning').show();
        }
        else {
            $('#claims-format-warning').hide();
            $('#claims-warning').hide();
            $('#claims-negative-number-warning').hide();
            validationCount++;
        }


        if (validationCount == 6) {
            if (myDropzone.getQueuedFiles().length > 0) {
                myDropzone.processQueue();
            } else {
                myDropzone.uploadFiles([{ name: 'nofiles' }]); //send empty

            }
        }
    }
}