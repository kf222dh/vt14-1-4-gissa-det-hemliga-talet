jQuery(document).ready(function ($) {
    if ($('#TextBox').attr('disabled') !== 'disabled') {
        $('#TextBox').focus().select();//Sätter fokus på textlådan och markerar innehållet åt en, detta körs när sidan laddas alltså når man öppnar den och när postback sker
    }
});