


window.blazorConfirmJsFunctions = {
  blazorConfirm: function (message) {
    var sortir = confirm(message);
    return sortir;
  },
  setOnbeforeunload: function () {
    window.onbeforeunload = function(){
      return 'Are you sure you want to leave?';
    };
  },
  unsetOnbeforeunload: function () {
    window.onbeforeunload = null;
  }
};

