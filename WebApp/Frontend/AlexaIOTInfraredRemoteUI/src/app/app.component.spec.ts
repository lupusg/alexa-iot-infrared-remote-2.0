import { TestBed, ComponentFixture } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientModule } from '@angular/common/http';
import { AuthModule, StsConfigLoader } from 'angular-auth-oidc-client';
import { AppComponent } from './app.component';
import { ButtonModule } from 'primeng/button';

describe('AppComponent', () => {
  let fixture: ComponentFixture<AppComponent>;
  let app: AppComponent;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule, HttpClientModule, AuthModule, ButtonModule],
      declarations: [AppComponent],
      providers: [StsConfigLoader],
    });

    fixture = TestBed.createComponent(AppComponent);
    app = fixture.componentInstance;
  });

  it('should create the app', () => {
    expect(app).toBeTruthy();
  });

  it(`should have as title 'AlexaIOTInfraredRemoteUI'`, () => {
    expect(app.title).toEqual('AlexaIOTInfraredRemoteUI');
  });
});
