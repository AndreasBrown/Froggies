export default class FrogDragOptions {
    public dropzoneSelector?: string

    public onDragStart?: (e: any) => void;

    public onDrag?: (e: any) => void;

    public onDragEnd?: (e: any) => void;
}