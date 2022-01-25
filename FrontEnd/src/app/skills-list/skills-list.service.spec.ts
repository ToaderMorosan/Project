import { TestBed } from '@angular/core/testing';

import { SkillsListService } from './skills-list.service';

describe('SkillsListService', () => {
  let service: SkillsListService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SkillsListService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
