export default function DisplayField(props: { label: string; value: string | number }) {
  return (
    <>
      <strong className="mr-2">{props.label}:</strong>
      {props.value}
    </>
  );
}
