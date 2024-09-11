import { Pipe, PipeTransform } from '@angular/core';

/**
 * Pipe para formatear valores monetarios con el símbolo de la divisa correspondiente.
 * @pipe
 */
@Pipe({
  name: 'customCurrency'
})
export class CustomCurrencyPipe implements PipeTransform {

  /**
   * Mapeo completo de códigos de moneda a símbolos.
   * @type {{ [key: string]: string }}
   */
  private currencySymbols: { [key: string]: string } = {
    'AED': 'د.إ',
    'AFN': 'Af',
    'ALL': 'L',
    'AMD': 'Դ',
    'ANG': 'ƒ',
    'AOA': 'Kz',
    'ARS': '$',
    'AUD': 'A$',
    'AWG': 'ƒ',
    'AZN': '₼',
    'BAM': 'KM',
    'BBD': '$',
    'BDT': '৳',
    'BGN': 'лв',
    'BHD': '.د.ب',
    'BIF': 'Fr',
    'BMD': '$',
    'BND': '$',
    'BOB': 'Bs',
    'BRL': 'R$',
    'BSD': '$',
    'BTN': 'Nu.',
    'BWP': 'P',
    'BYN': 'Br',
    'BZD': '$',
    'CAD': '$',
    'CDF': 'Fr',
    'CHF': 'CHF',
    'CLP': '$',
    'CNY': '¥',
    'COP': '$',
    'CRC': '₡',
    'CUC': '$',
    'CUP': '₵',
    'CVE': '$',
    'CZK': 'Kč',
    'DJF': 'Fdj',
    'DKK': 'kr',
    'DOP': 'RD$',
    'DZD': 'د.ج',
    'EGP': 'ج.م',
    'ERN': 'Nfa',
    'ETB': 'Br',
    'EUR': '€',
    'FJD': '$',
    'FKP': '£',
    'FOK': 'kr',
    'GBP': '£',
    'GEL': '₾',
    'GHS': '₵',
    'GIP': '£',
    'GMD': 'D',
    'GNF': 'Fr',
    'GTQ': 'Q',
    'GYD': '$',
    'HKD': 'HK$',
    'HNL': 'L',
    'HRK': 'kn',
    'HTG': 'G',
    'HUF': 'Ft',
    'IDR': 'Rp',
    'ILS': '₪',
    'INR': '₹',
    'IQD': 'ع.د',
    'IRR': '﷼',
    'ISK': 'kr',
    'JMD': '$',
    'JOD': '.د.ا',
    'JPY': '¥',
    'KES': 'KSh',
    'KGS': 'с',
    'KHR': '៛',
    'KID': '$',
    'KMF': 'Fr',
    'KRW': '₩',
    'KWD': 'د.ك',
    'KYD': '$',
    'KZT': '₸',
    'LAK': '₭',
    'LBP': 'ل.ل',
    'LKR': 'Rs',
    'LRD': '$',
    'LSL': 'M',
    'MAD': 'د.م.',
    'MDL': 'L',
    'MGA': 'Ar',
    'MKD': 'ден',
    'MMK': 'Ks',
    'MNT': '₮',
    'MOP': 'MOP$',
    'MRU': 'UM',
    'MUR': '₨',
    'MVR': 'Rf',
    'MWK': 'MK',
    'MXN': '$',
    'MYR': 'RM',
    'MZN': 'MT',
    'NAD': '$',
    'NGN': '₦',
    'NIO': 'C$',
    'NOK': 'kr',
    'NPR': 'Rs',
    'NZD': '$',
    'OMR': 'ر.ع.',
    'PAB': 'B/.',
    'PEN': 'S/',
    'PGK': 'K',
    'PHP': '₱',
    'PKR': 'Rs',
    'PLN': 'zł',
    'PYG': 'Gs',
    'QAR': 'ر.ق',
    'RON': 'lei',
    'RSD': 'дин.',
    'RUB': '₽',
    'RWF': 'Fr',
    'SAR': 'ر.س',
    'SBD': '$',
    'SCR': '₨',
    'SDG': 'ج.س.',
    'SEK': 'kr',
    'SGD': '$',
    'SHP': '£',
    'SLL': 'Le',
    'SOS': 'S',
    'SRD': '$',
    'SSP': '£',
    'STN': 'Db',
    'SYP': 'ل.س',
    'SZL': 'E',
    'THB': '฿',
    'TJS': 'SM',
    'TMT': 'T',
    'TND': 'د.ت',
    'TOP': 'T$',
    'TRY': '₺',
    'TTD': '$',
    'TVD': '$',
    'TZS': 'Sh',
    'UAH': '₴',
    'UGX': 'USh',
    'USD': '$',
    'UYU': '$U',
    'UZS': 'soʻm',
    'VES': 'Bs.S',
    'VND': '₫',
    'VUV': 'Vt',
    'WST': 'WS$',
    'XAF': 'FCFA',
    'XCD': '$',
    'XOF': 'CFA',
    'XPF': 'XPF',
    'YER': 'ر.ي',
    'ZAR': 'R',
    'ZMW': 'ZK',
    'ZWL': '$'
  };

  /**
   * Transforma un valor numérico en una cadena de texto formateada con el símbolo de la divisa.
   * @param {number} value - El valor numérico a formatear.
   * @param {string} [currencyCode=''] - El código de la divisa para obtener el símbolo (opcional).
   * @returns {string} - El valor formateado como una cadena de texto con el símbolo de la divisa.
   */
  transform(value: number, currencyCode: string = ''): string {
    if (value == null) return '';

    // Asegúrate de que el valor sea un número y formatea con dos decimales
    const formattedValue = parseFloat(value.toString()).toFixed(2);

    // Obtén el símbolo de la divisa basado en el código
    const currencySymbol = this.currencySymbols[currencyCode] || currencyCode;

    // Construir el resultado final con el símbolo de la divisa y un espacio
    return `${formattedValue} ${currencySymbol}`;
  }
}
