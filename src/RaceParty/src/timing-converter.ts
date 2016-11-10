import {TimeSpan} from 'src/laptimes';

export class TimingValueConverter {
  public toView(value: TimeSpan) {
    return `${value.minutes}:${value.seconds}:${value.milliseconds}`;
  }
}
