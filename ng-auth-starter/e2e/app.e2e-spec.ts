import { HelloWorldPage } from './app.po';

describe('hello-world App', () => {
  let page: HelloWorldPage;

  beforeEach(() => {
    page = new HelloWorldPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
