// import { GenerarExcel } from '../../../shared/utility/functions';
import { FormGroup } from '@angular/forms';


export function GeneratePDF(response:any){
        var blob = new Blob([this.s2ab(atob(response.file))], { type: 'application/pdf' });
        var a = document.createElement('a');
        var url = window.URL.createObjectURL(blob);
        a.href = url;
        a.download = response.fileName;
        a.click();
        window.URL.revokeObjectURL(url);
}

export function s2ab(s) {
        var buf = new ArrayBuffer(s.length);
        var view = new Uint8Array(buf);
        for (var i = 0; i !== s.length; ++i) view[i] = s.charCodeAt(i) & 0xFF;
        return buf;
}
	
export function GenerarExcel(response:any){
		var blob = new Blob([s2ab(atob(response.file))], { type: 'application/octet-stream' });
		var a = document.createElement('a');
		var url = window.URL.createObjectURL(blob);
		a.href = url;
		a.download = response.fileName;
		a.click();
		window.URL.revokeObjectURL(url);
}

export function notNullInput(val: any) {
  if (val == null)
    return '';
  else
    return val;
}

export function validForm(form: FormGroup) {
  var errors = [];
  for (const i in form.controls) {
    form.controls[i].markAsDirty();
    form.controls[i].updateValueAndValidity();
    var status = form.controls[i].status;
    if (status === 'INVALID') {
      errors.push(status);
    }
  }
  return errors.length === 0 ? true : false;
}