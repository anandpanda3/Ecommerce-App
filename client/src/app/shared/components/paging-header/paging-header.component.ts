import { Component, OnInit , Input} from '@angular/core';

@Component({
  selector: 'app-paging-header',
  templateUrl: './paging-header.component.html',
  styleUrls: ['./paging-header.component.scss']
})
export class PagingHeaderComponent implements OnInit {

  @Input() totalCount: Number;
  @Input() pageNumber: Number;
  @Input() pageSize: Number;

  constructor() { }

  ngOnInit(): void {

  }

}
