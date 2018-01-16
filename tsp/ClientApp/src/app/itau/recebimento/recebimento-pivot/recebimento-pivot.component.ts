import { Component, OnInit, AfterViewInit, OnChanges, ViewChild, Input } from '@angular/core';
import { CurrencyPipe } from '@angular/common';

import { DxChartComponent, DxPivotGridComponent } from 'devextreme-angular';

@Component({
  selector: 'app-recebimento-pivot',
  templateUrl: './recebimento-pivot.component.html',
  styleUrls: ['./recebimento-pivot.component.css'],
  providers: [CurrencyPipe]
})

export class RecebimentoPivotComponent implements OnChanges, AfterViewInit {
  @ViewChild(DxPivotGridComponent) pivotGrid: DxPivotGridComponent;
  @ViewChild(DxChartComponent) chart: DxChartComponent;
  @Input() queryResult: any;
  pivotGridDataSource: any;

  constructor(private currencyPipe: CurrencyPipe) {
      this.customizeTooltip = this.customizeTooltip.bind(this);
  }

  ngAfterViewInit() {
      this.pivotGrid.instance.bindChart(this.chart.instance, {
          dataFieldsDisplayMode: 'splitPanes',
          alternateDataFields: false
      });
  }

  ngOnChanges() {
      this.populate();
  }

  customizeTooltip(args: any) {
      const valueText = (args.seriesName.indexOf('Total') !== -1) ?
          this.currencyPipe.transform(args.originalValue, 'BRL', true, '1.2-2') :
          args.originalValue;

      return {
          html: args.seriesName + `<div class='currency'>` + valueText + '</div>'
      };
  }

  populate() {
      this.pivotGridDataSource = {
          fields: [{
              caption: 'UF',
              width: 120,
              dataField: 'uf_resid',
              area: 'row',
              sortOrder: 'desc',
              sortBySummaryField: 'R$'
          }, {
              caption: 'R$',
              dataField: 'valor_pago',
              summaryType: 'sum',
              format: {
                  type: 'currency',
                  precision: 2, // the precision of values
                  currency: 'BRL' // a specific 3-letter code for the 'currency' format
              },
              area: 'data'
          }, {
              caption: '# tickets',
              summaryType: 'count',
              area: 'data'
          }],
          store: this.queryResult
      }
  }
}
