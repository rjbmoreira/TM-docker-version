import { Customer } from './customer';
import { Project } from './project';

export interface TimeInput {
    id: number;
    projectId: number;
    timeSpent: number;
}