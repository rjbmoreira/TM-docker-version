import { TimeInput } from './timeinput';

export interface OverviewEntry {
    projectId: number,
    projectName: string,
    customerId: number,
    customerName: string,
    timeInputs: number[], //maybe change to a model type if more info is needed (e.g. time registration date/timestamp, etc)
    totalTime: number
}