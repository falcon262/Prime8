mergeInto(
  LibraryManager.library,
  {
    AddClickListenerForFileDialog: function () {
      document.addEventListener('click', function () {

        var fileuploader = document.getElementById('fileuploader');
        if (!fileuploader) {
          fileuploader = document.createElement('input');
          fileuploader.setAttribute('style', 'display:none;');
          fileuploader.setAttribute('type', 'file');
          fileuploader.setAttribute('id', 'fileuploader');
          fileuploader.setAttribute('class', '');
          document.getElementsByTagName('body')[0].appendChild(fileuploader);

          fileuploader.onchange = function (e) {
            var files = e.target.files;
            for (var i = 0, f; f = files[i]; i++) {
              SendMessage('upload sound icon', 'FileDialogResult', URL.createObjectURL(f));
            }
          };
        }
        if (fileuploader.getAttribute('class') == 'focused') {
          fileuploader.setAttribute('class', '');
          fileuploader.click();
        }
      });
    }
  }
);