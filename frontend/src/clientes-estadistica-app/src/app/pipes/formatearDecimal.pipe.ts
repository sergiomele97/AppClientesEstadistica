import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'formatearDecimal'
})
export class FormatearDecimalPipe implements PipeTransform {

  
  transform(value: number | null): number {
    if (value === null || value === undefined) {
      return 0;
    }
    return parseFloat(value.toFixed(2));
  }
}
