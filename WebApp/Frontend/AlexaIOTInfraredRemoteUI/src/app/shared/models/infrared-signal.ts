export interface InfraredSignal {
    id: string;
    state: boolean | string;
    description: string;
    infraredData: string;
    irSignalOutput: string;
    createdAt: Date;
}