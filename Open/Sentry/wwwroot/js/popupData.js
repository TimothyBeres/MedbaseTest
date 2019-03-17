$(document).ready(function() {
    $('#confirmationModalRemove').on('show.bs.modal',

        function (event) {
            var button = $(event.relatedTarget); // Button that triggered the modal
            var medicineId = button.data('id'); // Extract info from data-* attributes
            var medicineName = button.data('name');
            var categoryId = button.data('category');
            // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
            // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
            var modal = $(this);
            modal.find('.modal-title').text('Removing medicine from portfolio: ' + medicineName);

            modal.find('#categoryId').val(categoryId);
            modal.find('#medicineId').val(medicineId);
        });
    $('#confirmationModalAdd').on('show.bs.modal',

        function (event) {
            var button = $(event.relatedTarget); // Button that triggered the modal
            var medicineId = button.data('id'); // Extract info from data-* attributes
            var medicineName = button.data('name');
            // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
            // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
            var modal = $(this);
            modal.find('.modal-title').text('Adding medicine to portfolio: ' + medicineName);
            modal.find('.modal-body input').val(medicineId);
        });
});
    
