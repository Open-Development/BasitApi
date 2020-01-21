import { Component, OnInit } from '@angular/core';
import { DeviceService } from './device.service';
import { Light } from './Light';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  public lights: Light[];

  constructor(private service: DeviceService) {
    this.lights = [] as Light[];
  }

  ngOnInit() {
    this.service.get('light').subscribe(a => {
      this.lights = a;
      console.log(this.lights);
    });
  }
}
