import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'formaterFecha'
})
export class FormaterFechaPipe implements PipeTransform {

  constructor(private datePipe: DatePipe) {}

  transform(value: Date | string | null): string {
    if (!value) {
      return '';
    }
    return this.datePipe.transform(value, 'dd/MM/yy')!;
  }

}
